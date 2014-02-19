using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using CSharp.Basics.Sys.Tasks;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Web;
using SitecoreInstaller.Framework.Xml;

namespace SitecoreInstaller.Domain.Website
{
    public class WebsiteService
    {
        private const string _installerPath = "temp/SitecoreInstaller";
        private const string _keepAlivePingPath = "/sitecore/service/keepalive.aspx";

        private const string _adminLoginName = "AdminLogin.aspx";
        private const string _installPackageServiceName = "InstallPackageService.aspx";
        private const string _installPackageStatusName = "InstallPackageStatus.aspx";
        private const string _deserializeItemsName = "DeserializeItems.aspx";
        private const string _publishSiteName = "PublishSite.aspx";
        private const string _postInstallServiceName = "PostInstallService.aspx";

        public void SetDataFolder(DataFolder dataFolder, FileInfo dataFolderConfigFile)
        {
            var configFile = string.Format(WebsiteResource.DataFolderFormat, dataFolder.Directory);
            configFile.WriteToDisk(dataFolderConfigFile);
            Log.ToApp.Info("Data folder set to '{0}'", dataFolder.FullName);
        }

        public void CopySitecoreToProjectfolder(ProjectFolder projectFolder, BuildLibraryDirectory sitecore, DbInstallType sqlInstallType)
        {
            Log.ToApp.Info("Copying '{0}'...", sitecore.Directory.Name);

            //Copy web site folder
            var sitecoreWebsiteFolder = sitecore.Directory.CombineTo<DirectoryInfo>(projectFolder.Website.Name);
            sitecoreWebsiteFolder.CopyTo(projectFolder.Website, DirCopyOptions.IncludeSubDirectories);

            //Copy database folder
            if (sqlInstallType == DbInstallType.Local)
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

            Log.ToApp.Info("Sitecore copied");
        }

        private void CopyDatabaseFolder(string sourceDbName, DirectoryInfo sitecore, ProjectFolder projectfolder)
        {
            var sitecoreDatabaseFolder = sitecore.CombineTo<DirectoryInfo>(sourceDbName);
            if (Directory.Exists(sitecoreDatabaseFolder.FullName) == false)
                return;

            sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, FileTypes.DatabaseLogFile.GetAllSearchPattern);
            sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, FileTypes.DatabaseDataFile.GetAllSearchPattern);
        }

        public void CopyModulesToWebsite(ProjectFolder projectFolder, BuildLibraryDirectory module, DbInstallType sqlInstallType)
        {
            Log.ToApp.Info("Copying module to website...");

            if (sqlInstallType == DbInstallType.Local)
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
                    Log.ToApp.Warning(e.ToString());
                }
            }

            //copy powershell scripts to project root folder
            module.Directory.GetFiles(FileTypes.PowerShellScript).CopyTo(projectFolder, true);

            //copy config delta files to project root folder
            module.Directory.GetFiles(FileTypes.ConfigDelta).CopyTo(projectFolder, true);

            //copy config files to App_Config/Include folder
            module.Directory.GetFiles(FileTypes.SitecoreConfigFile).CopyTo(projectFolder.Website.AppConfig.Include, true);

            //copy disabled config files to App_Config/Include folder
            var disabledConfigFiles = module.Directory.GetFiles(FileTypes.DisabledSitecoreConfigFile).ToList();
            disabledConfigFiles.CopyTo(projectFolder.Website.AppConfig.Include, true);

            //copy Sitecore packages to package folder (zip files)
            module.Directory.GetFiles(FileTypes.SitecorePackage).CopyTo(projectFolder.Data.Packages, true);

            //copy Sitecore update packages to package folder (update files)
            module.Directory.GetFiles(FileTypes.SitecoreUpdate).CopyTo(projectFolder.Data.Packages, true);

            //Copy rest of files
            Array.FindAll(module.Directory.GetFiles(), FileTypes.IsNotRegisteredFileType).CopyTo(projectFolder, true);

            //Copy directories to project folder
            module.Directory.GetDirectories().CopyTo(projectFolder);

            Log.ToApp.Info("Module copied to website");
        }

        public void CopyStandAloneScPackagesToWebsite(ProjectFolder projectFolder, BuildLibraryFile file, DbInstallType sqlInstallType)
        {
            Log.ToApp.Info("Copying stand alone sitecore package to website...");

            if (file.File.IsSitecorePackage())
            {
                file.File.CopyTo(projectFolder.Data.Packages, true);
            }


            Log.ToApp.Info("Stand alone sitecore package copied to website");
        }

        public void TransformConfigFiles(IEnumerable<FileInfo> configDeltas, FileInfo webConfig, FileInfo connectionStrings)
        {
            webConfig.Refresh();
            connectionStrings.Refresh();


            var deltas = configDeltas.ToList();

            if (webConfig.Exists)
            {
                foreach (var configDelta in deltas.Where(file => FileTypes.ConfigDelta.IsType(file)).Where(file => file.Name.ToLowerInvariant().StartsWith("web")))
                {
                    XmlTransform.Transform(webConfig, File.ReadAllText(configDelta.FullName));
                }
            }
            if (connectionStrings.Exists)
            {
                foreach (var configDelta in deltas.Where(file => FileTypes.ConfigDelta.IsType(file)).Where(file => file.Name.ToLowerInvariant().StartsWith("connectionstrings")))
                {
                    XmlTransform.Transform(connectionStrings, File.ReadAllText(configDelta.FullName));
                }
            }
        }

        public void CopyLicenseFileToDataFolder(BuildLibraryFile license, DataFolder dataFolder, FileInfo licenseConfigFile)
        {
            Log.ToApp.Info("Copying license file '{0}'...", license.File.Name);

            var targetLicenseFileName = dataFolder.Directory.CombineTo<FileInfo>("license.xml");

            File.Copy(license.File.FullName, targetLicenseFileName.FullName, true);
            var licenseConfig = string.Format(WebsiteResource.LicenseFileFormat, targetLicenseFileName.Name);
            licenseConfig.WriteToDisk(licenseConfigFile);
            Log.ToApp.Info("License file copied to '{0}'", targetLicenseFileName.FullName);
        }

        public void OpenSitecore(string baseUrl, DirectoryInfo websiteFolder)
        {
            Log.ToApp.Info("Starting up Sitecore...");

            if (string.IsNullOrEmpty(baseUrl))
            {
                Log.ToApp.Error("baseUrl is null or empty");
                return;
            }

            //copy admin login
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);
            WebsiteResource.AdminLogin.WriteToDir(runtimeServicesFolder, _adminLoginName);

            TheWww.OpenInBrowser(baseUrl.ToUri(_installerPath, _adminLoginName));
        }

        public void OpenFrontend(string baseUrl)
        {
            Log.ToApp.Info("Accessing site...");

            if (string.IsNullOrEmpty(baseUrl))
            {
                Log.ToApp.Error("baseUrl is null or empty");
                return;
            }

            TheWww.OpenInBrowser(baseUrl.ToUri());
        }

        public void InstallRuntimeServices(WebsiteFolder websiteFolder)
        {
            Log.ToApp.Info("Installing runtime services...");

            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);

            runtimeServicesFolder.CreateIfNotExists();

            WebsiteResource.InstallPackageService.WriteToDir(runtimeServicesFolder, _installPackageServiceName);
            WebsiteResource.InstallPackageStatusService.WriteToDir(runtimeServicesFolder, _installPackageStatusName);
            WebsiteResource.DeserializeItems.WriteToDir(runtimeServicesFolder, _deserializeItemsName);
            WebsiteResource.PublishSite.WriteToDir(runtimeServicesFolder, _publishSiteName);

            Log.ToApp.Info("Runtime services installed");
        }

        public void DeleteRuntimeServices(DirectoryInfo websiteFolder)
        {
            //delete runtime services
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);

            if (runtimeServicesFolder.Exists == false)
            {
                Log.ToApp.Debug("Runtime services not found. Aborting...");
                return;
            }

            runtimeServicesFolder.DeleteWithLog();
        }

        public void OpenLogsInBareTail(DirectoryInfo logsDir)
        {
            if (logsDir == null)
                return;
            logsDir.Refresh();
            if (logsDir.Exists == false)
                return;

            var logFiles = logsDir.GetFiles("log.*.txt");

            BareTail.OpenLogs(logFiles);
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
            Log.ToApp.Info("Installing packages...");

            foreach (var module in modules)
            {
                foreach (var package in module.Directory.GetFiles(FileTypes.SitecorePackage))
                {
                    InstallPackage(baseUrl, package);
                }
                foreach (var update in module.Directory.GetFiles(FileTypes.SitecoreUpdate))
                {
                    InstallPackage(baseUrl, update);
                }
            }
        }

        public void InstallPackages(string baseUrl, IEnumerable<BuildLibraryFile> standAloneScPackages)
        {
            if (standAloneScPackages == null)
                return;
            standAloneScPackages = standAloneScPackages.ToList();

            if (standAloneScPackages.Any() == false)
                return;

            //warm up site to make sure run time service is up and running
            WakeUpSite(baseUrl);
            Log.ToApp.Info("Installing packages...");

            foreach (var standAloneScPackage in standAloneScPackages)
            {
                if (standAloneScPackage.File.IsSitecorePackage())
                    InstallPackage(baseUrl, standAloneScPackage.File);
            }
        }

        private void InstallPackage(string baseUrl, FileInfo package)
        {
            var packageName = HttpUtility.UrlEncode(package.Name);
            Log.ToApp.Info("Installing '{0}'...", HttpUtility.UrlDecode(packageName));

            const string installFormatPattern = "Action={0}&PackageName={1}";

            var callingUri = baseUrl.ToUri(_installerPath, _installPackageServiceName, "?" + string.Format(installFormatPattern, "Install", packageName));
            ExecuteInstallPackageAction(callingUri);

            Log.ToApp.Info("Executing post installation steps for '{0}'...", HttpUtility.UrlDecode(packageName));

            callingUri = baseUrl.ToUri(_installerPath, _installPackageServiceName, "?" + string.Format(installFormatPattern, "PostInstall", packageName));
            ExecuteInstallPackageAction(callingUri);

            Log.ToApp.Info("'{0}' is installed", package);
        }

        public void PublishSite(string baseUrl, PublishType publishType = PublishType.Full)
        {
            WakeUpSite(baseUrl);
            Log.ToApp.Info("Publishing site: {0}...", publishType);
            var callingUri = baseUrl.ToUri(_installerPath, _publishSiteName);
            TheWww.CallUrl(callingUri);
        }

        public void DeserializeItems(string baseUrl)
        {
            Log.ToApp.Info("Deserializing items...");
            var callingUri = baseUrl.ToUri(_installerPath, _deserializeItemsName);
            TheWww.CallUrl(callingUri);
        }

        public void ExecutePostInstallSteps(string baseUrl, DirectoryInfo websiteFolder)
        {
            //warm up site to make sure run time service is up and running
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);
            WebsiteResource.PostInstallService.WriteToDir(runtimeServicesFolder, _postInstallServiceName);
            WakeUpSite(baseUrl);
            Log.ToApp.Info("Executing post install steps...");
            var callingUri = baseUrl.ToUri(_installerPath, _postInstallServiceName);
            TheWww.CallUrl(callingUri);
        }

        public void WakeUpSite(string siteBaseUrl)
        {
            Log.ToApp.Info("Waking up site...");
            TheWww.CallUrl(siteBaseUrl.ToUri(_keepAlivePingPath));
        }

        public void CreateWffmConfigFile(string connectionString, FileInfo wffmConfigFile)
        {
            var formsDataString = string.Format(WebsiteResource.WffmDataProviderFormat, connectionString);
            formsDataString.WriteToDisk(wffmConfigFile);
        }

        private void ExecuteInstallPackageAction(Uri url)
        {
            HttpWebResponse response = null;
            var succeeded = Do.This(() =>
            {
                response = TheWww.CallUrlOnce(url);
            })
            .WithPing(() => Log.ToApp.Debug("Status code: '{0}' | Status description: '{1}'", response.StatusCode, response.StatusDescription))
            .Until(() => response.StatusCode == HttpStatusCode.OK || response.StatusDescription.StartsWith("Done"), TimeSpan.FromMinutes(20), 10);

            if (!succeeded)
            {
                Log.ToApp.Error("Faild to install {0}", url);
            }
        }
    }
}
