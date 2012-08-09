﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Website
{
    using System.Security.AccessControl;
    using System.Text;

    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;

    public class WebsiteService : IWebsiteService
    {
        private const string _InstallerPath = "DeleteMe";
        private const string _KeepAlivePingPath = "/sitecore/service/keepalive.aspx";
        private const string _SitecorePingPath = "/sitecore/login/";
        private const string _SiteRootPingPath = "/";
        private const string _TargetAssemblyPath = "bin";

        private const string _AdminLoginName = "AdminLogin.aspx";
        private const string _InstallPackageServiceName = "InstallPackageService.aspx";
        private const string _PostInstallServiceName = "PostInstallService.aspx";

        private const string _InstallerRunTimeServicesAssembly = "SitecoreInstaller.Runtime.dll";

        private readonly ILog _log;
        private readonly WebsiteFileTypes _websiteFileTypes;

        public WebsiteService(ILog log)
        {
            _log = log;
            _websiteFileTypes = new WebsiteFileTypes();
        }

        public void SetDataFolder(DirectoryInfo dataFolder, FileInfo dataFolderConfigFile)
        {
            var configFile = string.Format(WebsiteResource.DataFolderFormat, dataFolder);
            configFile.WriteToDisk(dataFolderConfigFile);
            _log.Info("Data folder set to '{0}'", dataFolder.FullName);
        }

        public void CreateTargetFolders(WebsiteFolders websiteFolders)
        {
            _log.Info("Creating website folders...");

            websiteFolders.ProjectFolder.CreateWithLog();

            _log.Debug("Giving Everyone user FullControl to project folder: {0}", websiteFolders.ProjectFolder.FullName);
            DirectorySecurity dirSec = Directory.GetAccessControl(websiteFolders.ProjectFolder.FullName);
            dirSec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            Directory.SetAccessControl(websiteFolders.ProjectFolder.FullName, dirSec);

            websiteFolders.CreateFolders();
            _log.Info("Website folders created");
        }

        public void CopySitecoreToProjectfolder(WebsiteFolders websiteFolders, BuildLibraryDirectory sitecore)
        {
            _log.Info("Copying '{0}'...", sitecore.Directory.Name);

            //Copy web site folder
            var sitecoreWebsiteFolder = sitecore.Directory.CombineTo<DirectoryInfo>(websiteFolders.WebSiteFolder.Name);
            sitecoreWebsiteFolder.CopyTo(websiteFolders.WebSiteFolder, DirCopyOptions.IncludeSubDirectories);

            //Copy database folder
            CopyDatabaseFolder("Database", sitecore.Directory, websiteFolders);
            CopyDatabaseFolder(WebsiteFolders.DatabasesFolderName, sitecore.Directory, websiteFolders);

            //Copy data folder
            var sitecoreDataFolder = sitecore.Directory.CombineTo<DirectoryInfo>(WebsiteFolders.DataFolderName);
            sitecoreDataFolder.CopyTo(websiteFolders.DataFolder, DirCopyOptions.IncludeSubDirectories);

            //Copy rest of files as is
            foreach (var file in sitecore.Directory.GetFiles())
                file.CopyTo(websiteFolders.ProjectFolder, true);

            _log.Info("Sitecore copied");
        }

        private void CopyDatabaseFolder(string sourceDbName, DirectoryInfo sitecore, WebsiteFolders websiteFolders)
        {
            var sitecoreDatabaseFolder = sitecore.CombineTo<DirectoryInfo>(sourceDbName);
            if (Directory.Exists(sitecoreDatabaseFolder.FullName) == false)
                return;

            sitecoreDatabaseFolder.CopyFlattenedTo(websiteFolders.DatabaseFolder, _websiteFileTypes.DatabaseLogFile.GetAllSearchPattern);
            sitecoreDatabaseFolder.CopyFlattenedTo(websiteFolders.DatabaseFolder, _websiteFileTypes.DatabaseDataFile.GetAllSearchPattern);
        }

        public void CopyModulesToWebsite(DirectoryInfo projectFolder, WebsiteFolders websiteFolders, IEnumerable<BuildLibraryDirectory> modules)
        {
            _log.Info("Copying modules to website...");

            foreach (var module in modules)
            {
                //copy database files to database folder
                foreach (var databaseFile in new[] { _websiteFileTypes.DatabaseDataFile.GetAllSearchPattern, _websiteFileTypes.DatabaseLogFile.GetAllSearchPattern }.SelectMany(fileExtensions => module.Directory.GetFiles(fileExtensions)))
                {
                    databaseFile.CopyTo(websiteFolders.DatabaseFolder, true);
                    _log.Debug("Module database file '{0}' copied to {1}", databaseFile.FullName, websiteFolders.DataFolder.FullName);
                }

                //copy config files to App_Config/Include folder
                foreach (var configFile in _websiteFileTypes.SitecoreConfigFile.GetFiles(module.Directory))
                {
                    configFile.CopyTo(websiteFolders.ConfigIncludeFolder, true);
                    _log.Debug("Module config file '{0}' copied to {1}", configFile.FullName, websiteFolders.ConfigIncludeFolder.FullName);
                }

                //copy Sitecore packages to package folder (zip files)
                foreach (var packageFile in _websiteFileTypes.SitecorePackage.GetFiles(module.Directory))
                {
                    packageFile.CopyTo(websiteFolders.PackagesFolder, true);
                    _log.Debug("Module Sitecore package file '{0}' copied to {1}", packageFile.FullName, websiteFolders.PackagesFolder.FullName);
                }

                //Copy directories to project folder
                foreach (var moduleFolder in module.Directory.GetDirectories())
                {
                    var targetFolder = projectFolder.Combine(moduleFolder);
                    moduleFolder.CopyTo(targetFolder, DirCopyOptions.IncludeSubDirectories);
                    _log.Debug("Modules folder '{0}' copied to {1}", projectFolder.FullName, targetFolder.FullName);
                }

                //Copy rest of files
                foreach (var notSitecoreSpecificFileType in Array.FindAll(module.Directory.GetFiles(), _websiteFileTypes.IsNotRegisteredFileType))
                {
                    notSitecoreSpecificFileType.CopyTo(projectFolder, true);
                    _log.Debug("NotSitecoreSpecificFile '{0}' copied to {1}", notSitecoreSpecificFileType.FullName, projectFolder.CombineTo<FileInfo>(notSitecoreSpecificFileType.Name).FullName);
                }
            }

            _log.Info("Modules copied to website");
        }

        public void CopyLicenseFileToDataFolder(BuildLibraryFile license, DirectoryInfo dataFolder, FileInfo licenseConfigFile)
        {
            _log.Info("Copying license file '{0}'...", license.File.Name);
            license.File.CopyTo(dataFolder, true);
            var licenseConfig = string.Format(WebsiteResource.LicenseFileFormat, license.File.Name);
            licenseConfig.WriteToDisk(licenseConfigFile);
            _log.Info("License file copied");
        }

        public void CreateProjectFolder(DirectoryInfo projectFolder)
        {
            projectFolder.CreateWithLog();
        }

        public void OpenSitecore(string baseUrl, DirectoryInfo websiteFolder)
        {
            _log.Info("Starting up Sitecore...");

            if (string.IsNullOrEmpty(baseUrl))
            {
                _log.Error("baseUrl is null or empty");
                return;
            }

            //copy admin login
            var adminLogin = new FileInfo(_AdminLoginName);
            adminLogin.CopyTo(websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath), true);

            OpenInBrowser(baseUrl.ToUri(_InstallerPath, _AdminLoginName));
        }

        public void OpenFrontend(string baseUrl)
        {
            _log.Info("Accessing site...");

            if (string.IsNullOrEmpty(baseUrl))
            {
                _log.Error("baseUrl is null or empty");
                return;
            }

            OpenInBrowser(baseUrl.ToUri());
        }

        public void DeleteProjectFolder(DirectoryInfo projectFolder)
        {
            _log.Info("Deleting project folder '{0}'", projectFolder.Name);

            projectFolder.DeleteWithLog();

            _log.Info("Project folder deleted");
        }

        public void InstallRuntimeServices(DirectoryInfo websiteFolder)
        {
            _log.Info("Installing runtime services...");

            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);
            if (Directory.Exists(runtimeServicesFolder.FullName))
                runtimeServicesFolder.Create();

            //copy install package service
            var installPackagesService = new FileInfo(_InstallPackageServiceName);
            installPackagesService.CopyTo(runtimeServicesFolder, true);

            //copy post install service
            var postInstallService = new FileInfo(_PostInstallServiceName);
            postInstallService.CopyTo(runtimeServicesFolder, true);

            //copy package assembly
            var runtimeServicesAssembly = new FileInfo(_InstallerRunTimeServicesAssembly);
            runtimeServicesAssembly.CopyTo(websiteFolder.CombineTo<DirectoryInfo>(_TargetAssemblyPath), true);

            _log.Info("Runtime services installed");
        }

        public void DeleteRuntimeServices(DirectoryInfo websiteFolder)
        {
            //delete runtime services
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);

            if (Directory.Exists(runtimeServicesFolder.FullName) == false)
            {
                _log.Debug("Runtime services not found. Aborting...");
                return;
            }

            foreach (var file in runtimeServicesFolder.GetFiles())
                file.Delete();

            //delete runtime services assembly
            var runtimeServicesAssembly = websiteFolder.CombineTo<FileInfo>(_TargetAssemblyPath, _InstallerRunTimeServicesAssembly);
            if (runtimeServicesAssembly.Exists == false)
                return;

            runtimeServicesAssembly.Delete();
        }

        public void InstallPackages(string baseUrl, IEnumerable<BuildLibraryDirectory> modules)
        {
            if (modules == null)
                return;
            if (modules.Any() == false)
                return;

            //warm up site to make sure run time service is up and running
            WakeUpSite(baseUrl);
            _log.Info("Installing packages...");

            foreach (var module in modules)
            {
                foreach (var package in _websiteFileTypes.SitecorePackage.GetFiles(module.Directory))
                {
                    var packageName = HttpUtility.UrlEncode(package.Name);
                    _log.Info("Installing '{0}'", HttpUtility.UrlDecode(packageName));
                    var invoke = "Install=" + packageName;
                    var callingUri = baseUrl.ToUri(_InstallerPath, _InstallPackageServiceName, "?" + invoke);
                    CallUrl(callingUri);
                }
            }
        }

        public void ExecutePostInstallSteps(string baseUrl)
        {
            //warm up site to make sure run time service is up and running
            WakeUpSite(baseUrl);
            _log.Info("Executing post install steps...");
            var callingUri = baseUrl.ToUri(_InstallerPath, _PostInstallServiceName);
            CallUrl(callingUri);
        }


        public void WakeUpSite(string siteBaseUrl)
        {
            _log.Info("Waking up site...");
            CallUrl(siteBaseUrl.ToUri(_KeepAlivePingPath));
        }

        public void WarmUpSite(string siteBaseUrl)
        {
            _log.Info("Warming up site...");
            CallUrl(siteBaseUrl.ToUri(_SitecorePingPath));
            CallUrl(siteBaseUrl.ToUri(_SiteRootPingPath));
        }

        public void CreateWffmConfigFile(string connectionString, FileInfo wffmConfigFile)
        {
            var formsDataString = string.Format(WebsiteResource.WffmDataProviderFormat, connectionString);
            formsDataString.WriteToDisk(wffmConfigFile);
        }

        private void CallUrl(Uri url)
        {
            const int retries = 100;

            for (var tryCount = 1; tryCount <= retries; tryCount++)
            {
                try
                {
                    var webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
                    webRequest.AllowAutoRedirect = false;
                    webRequest.Timeout = (1000 * 60 * 30); //30 minutes in miliseconds
                    var response = (HttpWebResponse)webRequest.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        _log.Debug("'{0}' responded: '{1}'", url.ToString(), response.StatusDescription);
                        return;
                    }
                }
                catch (WebException we)
                {
                    /*_log.Error(we.Message);
                    _log.Info("IIS not ready. Retry #{0}...", tryCount);*/
                }
            }
            _log.Error("'{0}' never responded OK.", url.ToString());
        }

        public void OpenInBrowser(Uri url)
        {
            var command = "start " + url;
            var cmd = new CommandPrompt();
            cmd.Run(command);
        }
    }
}
