using System;
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

        private const string _AdminLoginName = "AdminLogin.aspx";
        private const string _InstallPackageServiceName = "InstallPackageService.aspx";
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
            Log.As.Info("Data folder set to '{0}'", dataFolder.FullName);
        }

        public void CopySitecoreToProjectfolder(ProjectFolder projectFolder, BuildLibraryDirectory sitecore)
        {
            Log.As.Info("Copying '{0}'...", sitecore.Directory.Name);

            //Copy web site folder
            var sitecoreWebsiteFolder = sitecore.Directory.CombineTo<DirectoryInfo>(projectFolder.Website.Name);
            sitecoreWebsiteFolder.CopyTo(projectFolder.Website, DirCopyOptions.IncludeSubDirectories);

            //Copy database folder
            CopyDatabaseFolder("Database", sitecore.Directory, projectFolder);
            CopyDatabaseFolder(projectFolder.Databases.Name, sitecore.Directory, projectFolder);

            //Copy data folder
            var sitecoreDataFolder = sitecore.Directory.CombineTo<DirectoryInfo>("data");
            sitecoreDataFolder.CopyTo(projectFolder.Data, DirCopyOptions.IncludeSubDirectories);

            //Copy rest of files as is
            foreach (var file in sitecore.Directory.GetFiles())
                file.CopyTo(projectFolder, true);

            Log.As.Info("Sitecore copied");
        }

        private void CopyDatabaseFolder(string sourceDbName, DirectoryInfo sitecore, ProjectFolder projectfolder)
        {
            var sitecoreDatabaseFolder = sitecore.CombineTo<DirectoryInfo>(sourceDbName);
            if (Directory.Exists(sitecoreDatabaseFolder.FullName) == false)
                return;

            sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, _fileTypes.DatabaseLogFile.GetAllSearchPattern);
            sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, _fileTypes.DatabaseDataFile.GetAllSearchPattern);
        }

        public void CopyModulesToWebsite(ProjectFolder projectFolder, IEnumerable<BuildLibraryDirectory> modules)
        {
            Log.As.Info("Copying modules to website...");

            foreach (var module in modules)
            {
                //copy database files to database folder
                foreach (var databaseFile in new[] { _fileTypes.DatabaseDataFile.GetAllSearchPattern, _fileTypes.DatabaseLogFile.GetAllSearchPattern }.SelectMany(fileExtensions => module.Directory.GetFiles(fileExtensions)))
                {
                    databaseFile.CopyTo(projectFolder.Databases, true);
                    Log.As.Debug("Module database file '{0}' copied to {1}", databaseFile.FullName, projectFolder.Data.FullName);
                }

                //copy config files to App_Config/Include folder
                foreach (var configFile in _fileTypes.SitecoreConfigFile.GetFiles(module.Directory))
                {
                    configFile.CopyTo(projectFolder.Website.AppConfig, true);
                    Log.As.Debug("Module config file '{0}' copied to {1}", configFile.FullName, projectFolder.Website.AppConfig.FullName);
                }

                //copy Sitecore packages to package folder (zip files)
                foreach (var packageFile in _fileTypes.SitecorePackage.GetFiles(module.Directory))
                {
                    packageFile.CopyTo(projectFolder.Data.Packages, true);
                    Log.As.Debug("Module Sitecore package file '{0}' copied to {1}", packageFile.FullName, projectFolder.Data.Packages.FullName);
                }

                //Copy directories to project folder
                foreach (var moduleFolder in module.Directory.GetDirectories())
                {
                    var targetFolder = projectFolder.Combine(moduleFolder);
                    moduleFolder.CopyTo(targetFolder, DirCopyOptions.IncludeSubDirectories);
                    Log.As.Debug("Modules folder '{0}' copied to {1}", projectFolder.FullName, targetFolder.FullName);
                }

                //Copy rest of files
                foreach (var notSitecoreSpecificFileType in Array.FindAll(module.Directory.GetFiles(), _fileTypes.IsNotRegisteredFileType))
                {
                    notSitecoreSpecificFileType.CopyTo(projectFolder, true);
                    Log.As.Debug("NotSitecoreSpecificFile '{0}' copied to {1}", notSitecoreSpecificFileType.FullName, projectFolder.CombineTo<FileInfo>(notSitecoreSpecificFileType.Name).FullName);
                }
            }

            Log.As.Info("Modules copied to website");
        }

        public void CopyLicenseFileToDataFolder(BuildLibraryFile license, DataFolder dataFolder, FileInfo licenseConfigFile)
        {
            Log.As.Info("Copying license file '{0}'...", license.File.Name);
            license.File.CopyTo(dataFolder.Directory, true);
            var licenseConfig = string.Format(WebsiteResource.LicenseFileFormat, license.File.Name);
            licenseConfig.WriteToDisk(licenseConfigFile);
            Log.As.Info("License file copied");
        }

        public void OpenSitecore(string baseUrl, DirectoryInfo websiteFolder)
        {
            Log.As.Info("Starting up Sitecore...");

            if (string.IsNullOrEmpty(baseUrl))
            {
                Log.As.Error("baseUrl is null or empty");
                return;
            }

            //copy admin login
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);
            WebsiteResource.AdminLogin.WriteToDir(runtimeServicesFolder, _AdminLoginName);

            OpenInBrowser(baseUrl.ToUri(_InstallerPath, _AdminLoginName));
        }

        public void OpenFrontend(string baseUrl)
        {
            Log.As.Info("Accessing site...");

            if (string.IsNullOrEmpty(baseUrl))
            {
                Log.As.Error("baseUrl is null or empty");
                return;
            }

            OpenInBrowser(baseUrl.ToUri());
        }



        public void InstallRuntimeServices(WebsiteFolder websiteFolder)
        {
            Log.As.Info("Installing runtime services...");

            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);

            runtimeServicesFolder.CreateIfNotExists();

            //copy install package service
            WebsiteResource.InstallPackageService.WriteToDir(runtimeServicesFolder, _InstallPackageServiceName);

            //copy post install service
            WebsiteResource.PostInstallService.WriteToDir(runtimeServicesFolder, _PostInstallServiceName);

            Log.As.Info("Runtime services installed");
        }

        public void DeleteRuntimeServices(DirectoryInfo websiteFolder)
        {
            //delete runtime services
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);

            if (runtimeServicesFolder.Exists == false)
            {
                Log.As.Debug("Runtime services not found. Aborting...");
                return;
            }

            runtimeServicesFolder.DeleteWithLog();
        }

        public void InstallPackages(string baseUrl, IEnumerable<BuildLibraryDirectory> modules)
        {
            if (modules == null)
                return;
            if (modules.Any() == false)
                return;

            //warm up site to make sure run time service is up and running
            WakeUpSite(baseUrl);
            Log.As.Info("Installing packages...");

            foreach (var module in modules)
            {
                foreach (var package in _fileTypes.SitecorePackage.GetFiles(module.Directory))
                {
                    var packageName = HttpUtility.UrlEncode(package.Name);
                    Log.As.Info("Installing '{0}'", HttpUtility.UrlDecode(packageName));
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
            Log.As.Info("Executing post install steps...");
            var callingUri = baseUrl.ToUri(_InstallerPath, _PostInstallServiceName);
            CallUrl(callingUri);
        }


        public void WakeUpSite(string siteBaseUrl)
        {
            Log.As.Info("Waking up site...");
            CallUrl(siteBaseUrl.ToUri(_KeepAlivePingPath));
        }

        public void WarmUpSite(string siteBaseUrl)
        {
            Log.As.Info("Warming up site...");
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
                        Log.As.Debug("'{0}' responded: '{1}'", url.ToString(), response.StatusDescription);
                        return;
                    }
                }
                catch (WebException we)
                {
                    /*Log.As.Error(we.Message);
                    Log.As.Info("IIS not ready. Retry #{0}...", tryCount);*/
                }
            }
            Log.As.Error("'{0}' never responded OK.", url.ToString());
        }

        public void OpenInBrowser(Uri url)
        {
            var command = "start " + url;
            var cmd = new CommandPrompt();
            cmd.Run(command);
        }
    }
}
