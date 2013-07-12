﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Website
{
  using System.Threading;
  using System.Threading.Tasks;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Sys;

  public class WebsiteService : IWebsiteService
  {
    private const string _InstallerPath = "temp/SitecoreInstaller";
    private const string _KeepAlivePingPath = "/sitecore/service/keepalive.aspx";
    private const string _SitecorePingPath = "/sitecore/login/";
    private const string _SiteRootPingPath = "/";

    private const string _AdminLoginName = "AdminLogin.aspx";
    private const string _InstallPackageServiceName = "InstallPackageService.aspx";
    private const string _InstallPackageStatusName = "InstallPackageStatus.aspx";
    private const string _DeserializeItemsName = "DeserializeItems.aspx";
    private const string _PostInstallServiceName = "PostInstallService.aspx";

    private readonly FileTypes _fileTypes;

    public WebsiteService()
    {
      _fileTypes = new FileTypes();
    }

    public void SetDataFolder(DataFolder dataFolder, FileInfo dataFolderConfigFile)
    {
      var configFile = string.Format(WebsiteResource.DataFolderFormat, dataFolder.Directory);
      configFile.WriteToDisk(dataFolderConfigFile);
      Log.This.Info("Data folder set to '{0}'", dataFolder.FullName);
    }

    public void CopySitecoreToProjectfolder(ProjectFolder projectFolder, BuildLibraryDirectory sitecore, InstallType installType)
    {
      Log.This.Info("Copying '{0}'...", sitecore.Directory.Name);

      //Copy web site folder
      var sitecoreWebsiteFolder = sitecore.Directory.CombineTo<DirectoryInfo>(projectFolder.Website.Name);
      sitecoreWebsiteFolder.CopyTo(projectFolder.Website, DirCopyOptions.IncludeSubDirectories);

      //Copy database folder
      if (installType == InstallType.Full)
      {
        //TODO: Move database folder name to central location
        CopyDatabaseFolder("Database", sitecore.Directory, projectFolder);
        CopyDatabaseFolder(projectFolder.Databases.Name, sitecore.Directory, projectFolder);
      }

      //Copy data folder
      //TODO: Move data folder name to central location
      var sitecoreDataFolder = sitecore.Directory.CombineTo<DirectoryInfo>("data");
      sitecoreDataFolder.CopyTo(projectFolder.Data, DirCopyOptions.IncludeSubDirectories);

      //Copy rest of files as is
      foreach (var file in sitecore.Directory.GetFiles())
        file.CopyTo(projectFolder, true);

      Log.This.Info("Sitecore copied");
    }

    private void CopyDatabaseFolder(string sourceDbName, DirectoryInfo sitecore, ProjectFolder projectfolder)
    {
      var sitecoreDatabaseFolder = sitecore.CombineTo<DirectoryInfo>(sourceDbName);
      if (Directory.Exists(sitecoreDatabaseFolder.FullName) == false)
        return;

      sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, _fileTypes.DatabaseLogFile.GetAllSearchPattern);
      sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, _fileTypes.DatabaseDataFile.GetAllSearchPattern);
    }

    public void CopyModulesToWebsite(ProjectFolder projectFolder, BuildLibraryDirectory module, InstallType installType)
    {
      Log.This.Info("Copying module to website...");

      if (installType == InstallType.Full)
      {
        try
        {
          //copy database files to database folder
          foreach (var databaseFile in new[] { _fileTypes.DatabaseDataFile.GetAllSearchPattern, _fileTypes.DatabaseLogFile.GetAllSearchPattern }.SelectMany(fileExtensions => module.Directory.GetFiles(fileExtensions)))
          {
            databaseFile.CopyTo(projectFolder.Databases, true);
            Log.This.Debug("Module database file '{0}' copied to {1}", databaseFile.FullName, projectFolder.Data.FullName);
          }
        }
        catch (IOException e)
        {
          Log.This.Warning(e.ToString());
        }
      }

      //copy config files to App_Config/Include folder
      foreach (var configFile in _fileTypes.SitecoreConfigFile.GetFiles(module.Directory))
      {
        var targetFolder = projectFolder.Website.AppConfig.Include;
        configFile.CopyTo(targetFolder, true);
        Log.This.Debug("Module config file '{0}' copied to {1}", configFile.FullName, targetFolder);
      }

      //copy Sitecore packages to package folder (zip files)
      foreach (var packageFile in _fileTypes.SitecorePackage.GetFiles(module.Directory))
      {
        packageFile.CopyTo(projectFolder.Data.Packages, true);
        Log.This.Debug("Module Sitecore package file '{0}' copied to {1}", packageFile.FullName, projectFolder.Data.Packages.FullName);
      }

      //copy Sitecore update packages to package folder (update files)
      foreach (var updateFile in _fileTypes.SitecoreUpdate.GetFiles(module.Directory))
      {
        updateFile.CopyTo(projectFolder.Data.Packages, true);
        Log.This.Debug("Module Sitecore update file '{0}' copied to {1}", updateFile.FullName, projectFolder.Data.Packages.FullName);
      }

      //Copy directories to project folder
      foreach (var moduleFolder in module.Directory.GetDirectories())
      {
        var targetFolder = projectFolder.Combine(moduleFolder);
        moduleFolder.CopyTo(targetFolder, DirCopyOptions.IncludeSubDirectories);
        Log.This.Debug("Modules folder '{0}' copied to {1}", projectFolder.FullName, targetFolder.FullName);
      }

      //Copy rest of files
      foreach (var notSitecoreSpecificFileType in Array.FindAll(module.Directory.GetFiles(), _fileTypes.IsNotRegisteredFileType))
      {
        notSitecoreSpecificFileType.CopyTo(projectFolder, true);
        Log.This.Debug("NotSitecoreSpecificFile '{0}' copied to {1}", notSitecoreSpecificFileType.FullName, projectFolder.CombineTo<FileInfo>(notSitecoreSpecificFileType.Name).FullName);
      }


      Log.This.Info("Module copied to website");
    }

    public void CopyLicenseFileToDataFolder(BuildLibraryFile license, DataFolder dataFolder, FileInfo licenseConfigFile)
    {
      Log.This.Info("Copying license file '{0}'...", license.File.Name);

      var targetLicenseFileName = dataFolder.Directory.CombineTo<FileInfo>("license.xml");

      File.Copy(license.File.FullName, targetLicenseFileName.FullName, true);
      var licenseConfig = string.Format(WebsiteResource.LicenseFileFormat, targetLicenseFileName.Name);
      licenseConfig.WriteToDisk(licenseConfigFile);
      Log.This.Info("License file copied to '{0}'", targetLicenseFileName.FullName);
    }

    public void OpenSitecore(string baseUrl, DirectoryInfo websiteFolder)
    {
      Log.This.Info("Starting up Sitecore...");

      if (string.IsNullOrEmpty(baseUrl))
      {
        Log.This.Error("baseUrl is null or empty");
        return;
      }

      //copy admin login
      var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);
      WebsiteResource.AdminLogin.WriteToDir(runtimeServicesFolder, _AdminLoginName);

      OpenInBrowser(baseUrl.ToUri(_InstallerPath, _AdminLoginName));
    }

    public void OpenFrontend(string baseUrl)
    {
      Log.This.Info("Accessing site...");

      if (string.IsNullOrEmpty(baseUrl))
      {
        Log.This.Error("baseUrl is null or empty");
        return;
      }

      OpenInBrowser(baseUrl.ToUri());
    }

    public void InstallRuntimeServices(WebsiteFolder websiteFolder)
    {
      Log.This.Info("Installing runtime services...");

      var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);

      runtimeServicesFolder.CreateIfNotExists();

      WebsiteResource.InstallPackageService.WriteToDir(runtimeServicesFolder, _InstallPackageServiceName);
      WebsiteResource.InstallPackageStatusService.WriteToDir(runtimeServicesFolder, _InstallPackageStatusName);
      WebsiteResource.DeserializeItems.WriteToDir(runtimeServicesFolder, _DeserializeItemsName);

      Log.This.Info("Runtime services installed");
    }

    public void DeleteRuntimeServices(DirectoryInfo websiteFolder)
    {
      //delete runtime services
      var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);

      if (runtimeServicesFolder.Exists == false)
      {
        Log.This.Debug("Runtime services not found. Aborting...");
        return;
      }

      runtimeServicesFolder.DeleteWithLog();
    }

    public void InstallPackages(string baseUrl, IEnumerable<BuildLibraryDirectory> modules)
    {
      if (modules == null)
        return;
      modules = modules.ToList();

      if (modules.Any() == false)
        return;

      //warm up site to make sure run time service is up and running
      WakeUpSite(baseUrl);
      Log.This.Info("Installing packages...");

      foreach (var module in modules)
      {
        foreach (var package in _fileTypes.SitecorePackage.GetFiles(module.Directory))
        {
          this.InstallPackage(baseUrl, package);
        }
        foreach (var update in _fileTypes.SitecoreUpdate.GetFiles(module.Directory))
        {
          this.InstallPackage(baseUrl, update);
        }
      }
    }

    private void InstallPackage(string baseUrl, FileInfo package)
    {
      var packageName = HttpUtility.UrlEncode(package.Name);
      Log.This.Info("Installing '{0}'...", HttpUtility.UrlDecode(packageName));

      const string installFormatPattern = "Action={0}&PackageName={1}";

      var callingUri = baseUrl.ToUri(_InstallerPath, _InstallPackageServiceName, "?" + string.Format(installFormatPattern, "Install", packageName));
      this.ExecuteInstallPackageAction(callingUri);

      Log.This.Info("Executing post installation steps for '{0}'...", HttpUtility.UrlDecode(packageName));

      callingUri = baseUrl.ToUri(_InstallerPath, _InstallPackageServiceName, "?" + string.Format(installFormatPattern, "PostInstall", packageName));
      this.ExecuteInstallPackageAction(callingUri);

      Log.This.Info("'{0}' is installed", package);
    }

    public void DeserializeItems(string baseUrl)
    {
      Log.This.Info("Deserializing items...");
      var callingUri = baseUrl.ToUri(_InstallerPath, _DeserializeItemsName);
      CallUrl(callingUri);
    }

    public void ExecutePostInstallSteps(string baseUrl, DirectoryInfo websiteFolder)
    {
      //warm up site to make sure run time service is up and running
      var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);
      WebsiteResource.PostInstallService.WriteToDir(runtimeServicesFolder, _PostInstallServiceName);
      WakeUpSite(baseUrl);
      Log.This.Info("Executing post install steps...");
      var callingUri = baseUrl.ToUri(_InstallerPath, _PostInstallServiceName);
      CallUrl(callingUri);
    }

    public void WakeUpSite(string siteBaseUrl)
    {
      Log.This.Info("Waking up site...");
      CallUrl(siteBaseUrl.ToUri(_KeepAlivePingPath));
    }

    public void WarmUpSite(string siteBaseUrl)
    {
      Log.This.Info("Warming up site...");
      CallUrl(siteBaseUrl.ToUri(_SitecorePingPath));
      CallUrl(siteBaseUrl.ToUri(_SiteRootPingPath));
    }

    public void CreateWffmConfigFile(string connectionString, FileInfo wffmConfigFile)
    {
      var formsDataString = string.Format(WebsiteResource.WffmDataProviderFormat, connectionString);
      formsDataString.WriteToDisk(wffmConfigFile);
    }

    private void ExecuteInstallPackageAction(Uri url)
    {
      HttpWebResponse response;
      do
      {
        response = this.FetchUrl(url);
        if (response == null)
        {
          Log.This.Error("Faild to install {0}", url);
          return;
        }
        Thread.Sleep(1000);
      }
      while (response.StatusCode != HttpStatusCode.OK && response.StatusDescription.StartsWith("Done") == false);
    }

    private void CallUrl(Uri url)
    {
      const int retries = 100;

      for (var tryCount = 1; tryCount <= retries; tryCount++)
      {
        var response = this.FetchUrl(url);
        if (response != null && response.StatusCode == HttpStatusCode.OK)
        {
          Log.This.Debug("'{0}' responded: '{1}'", url.ToString(), response.StatusDescription);
          return;
        }
      }
      Log.This.Error("'{0}' never responded OK.", url.ToString());
    }

    private HttpWebResponse FetchUrl(Uri url)
    {
      try
      {
        var webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
        webRequest.AllowAutoRedirect = false;
        webRequest.Timeout = (1000 * 60 * 30); //30 minutes in miliseconds
        return (HttpWebResponse)webRequest.GetResponse();
      }
      catch (WebException we)
      {
        Log.This.Debug(we.ToString());
        return null;
      }
    }

    public void OpenInBrowser(Uri url)
    {
      const string openBrowserFormat = @"""start"" {0}";
      var command = string.Format(openBrowserFormat, url);
      var cmd = new CommandPrompt();
      cmd.Run(command);
    }
  }
}
