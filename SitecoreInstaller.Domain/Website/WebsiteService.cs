using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;


using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Website
{
  using System.Threading;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Web;

  public class WebsiteService : IWebsiteService
  {
    private const string _InstallerPath = "temp/SitecoreInstaller";
    private const string _KeepAlivePingPath = "/sitecore/service/keepalive.aspx";
    
    private const string _AdminLoginName = "AdminLogin.aspx";
    private const string _InstallPackageServiceName = "InstallPackageService.aspx";
    private const string _InstallPackageStatusName = "InstallPackageStatus.aspx";
    private const string _DeserializeItemsName = "DeserializeItems.aspx";
    private const string _PostInstallServiceName = "PostInstallService.aspx";

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
      sitecore.Directory.GetFiles().CopyTo(projectFolder, true);

      Log.This.Info("Sitecore copied");
    }

    private void CopyDatabaseFolder(string sourceDbName, DirectoryInfo sitecore, ProjectFolder projectfolder)
    {
      var sitecoreDatabaseFolder = sitecore.CombineTo<DirectoryInfo>(sourceDbName);
      if (Directory.Exists(sitecoreDatabaseFolder.FullName) == false)
        return;

      sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, FileTypes.DatabaseLogFile.GetAllSearchPattern);
      sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, FileTypes.DatabaseDataFile.GetAllSearchPattern);
    }

    public void CopyModulesToWebsite(ProjectFolder projectFolder, BuildLibraryDirectory module, InstallType installType)
    {
      Log.This.Info("Copying module to website...");

      if (installType == InstallType.Full)
      {
        try
        {
          //copy database files to database folder
          var dbFiles = new[]
          {
            FileTypes.DatabaseDataFile.GetAllSearchPattern, FileTypes.DatabaseLogFile.GetAllSearchPattern
          }.SelectMany(fileExtensions => module.Directory.GetFiles(fileExtensions));

          dbFiles.CopyTo(projectFolder.Databases, true);
        }
        catch (IOException e)
        {
          Log.This.Warning(e.ToString());
        }
      }

      //copy powershell scripts to project root folder
      FileTypes.PowerShellScript.GetFiles(module.Directory).CopyTo(projectFolder, true);

      //copy config files to App_Config/Include folder
      FileTypes.SitecoreConfigFile.GetFiles(module.Directory).CopyTo(projectFolder.Website.AppConfig.Include, true);

      //copy Sitecore packages to package folder (zip files)
      FileTypes.SitecorePackage.GetFiles(module.Directory).CopyTo(projectFolder.Data.Packages, true);

      //copy Sitecore update packages to package folder (update files)
      FileTypes.SitecoreUpdate.GetFiles(module.Directory).CopyTo(projectFolder.Data.Packages, true);

      //Copy rest of files
      Array.FindAll(module.Directory.GetFiles(), FileTypes.IsNotRegisteredFileType).CopyTo(projectFolder, true);

      //Copy directories to project folder
      module.Directory.GetDirectories().CopyTo(projectFolder);
      
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

      TheWww.OpenInBrowser(baseUrl.ToUri(_InstallerPath, _AdminLoginName));
    }

    public void OpenFrontend(string baseUrl)
    {
      Log.This.Info("Accessing site...");

      if (string.IsNullOrEmpty(baseUrl))
      {
        Log.This.Error("baseUrl is null or empty");
        return;
      }

      TheWww.OpenInBrowser(baseUrl.ToUri());
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
        foreach (var package in FileTypes.SitecorePackage.GetFiles(module.Directory))
        {
          this.InstallPackage(baseUrl, package);
        }
        foreach (var update in FileTypes.SitecoreUpdate.GetFiles(module.Directory))
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
      TheWww.CallUrl(callingUri);
    }

    public void ExecutePostInstallSteps(string baseUrl, DirectoryInfo websiteFolder)
    {
      //warm up site to make sure run time service is up and running
      var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);
      WebsiteResource.PostInstallService.WriteToDir(runtimeServicesFolder, _PostInstallServiceName);
      WakeUpSite(baseUrl);
      Log.This.Info("Executing post install steps...");
      var callingUri = baseUrl.ToUri(_InstallerPath, _PostInstallServiceName);
      TheWww.CallUrl(callingUri);
    }

    public void WakeUpSite(string siteBaseUrl)
    {
      Log.This.Info("Waking up site...");
      TheWww.CallUrl(siteBaseUrl.ToUri(_KeepAlivePingPath));
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
        response = TheWww.CallUrlOnce(url);
        if (response == null)
        {
          Log.This.Error("Faild to install {0}", url);
          return;
        }
        Thread.Sleep(1000);
      }
      while (response.StatusCode != HttpStatusCode.OK && response.StatusDescription.StartsWith("Done") == false);
    }
  }
}
