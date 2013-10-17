using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Web;
using SitecoreInstaller.Framework.Xml;

namespace SitecoreInstaller.Domain.Website
{
    public class WebsiteService
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
            Log.As.Info("Data folder set to '{0}'", dataFolder.FullName);
        }

        public void CopySitecoreToProjectfolder(ProjectFolder projectFolder, BuildLibraryDirectory sitecore, InstallType installType)
        {
            Log.As.Info("Copying '{0}'...", sitecore.Directory.Name);

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

            Log.As.Info("Sitecore copied");
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
            Log.As.Info("Copying module to website...");

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
                    Log.As.Warning(e.ToString());
                }
            }

            //copy powershell scripts to project root folder
            module.Directory.GetFiles(FileTypes.PowerShellScript).CopyTo(projectFolder, true);

            //copy config delta files to project root folder
            module.Directory.GetFiles(FileTypes.ConfigDelta).CopyTo(projectFolder, true);

            //copy config files to App_Config/Include folder
            module.Directory.GetFiles(FileTypes.SitecoreConfigFile).CopyTo(projectFolder.Website.AppConfig.Include, true);

            //copy Sitecore packages to package folder (zip files)
            module.Directory.GetFiles(FileTypes.SitecorePackage).CopyTo(projectFolder.Data.Packages, true);

            //copy Sitecore update packages to package folder (update files)
            module.Directory.GetFiles(FileTypes.SitecoreUpdate).CopyTo(projectFolder.Data.Packages, true);

            //Copy rest of files
            Array.FindAll(module.Directory.GetFiles(), FileTypes.IsNotRegisteredFileType).CopyTo(projectFolder, true);

            //Copy directories to project folder
            module.Directory.GetDirectories().CopyTo(projectFolder);

            Log.As.Info("Module copied to website");
        }

        public void TransformConfigFiles(IEnumerable<FileInfo> configDeltas, FileInfo webConfig, FileInfo connectionStrings)
        {
            webConfig.Refresh();
            connectionStrings.Refresh();
            var transform = new XmlTransform();

            var deltas = configDeltas.ToList();

            if (webConfig.Exists)
            {
                foreach (var configDelta in deltas.Where(file => FileTypes.ConfigDelta.IsType(file)).Where(file => file.Name.ToLowerInvariant().StartsWith("web")))
                {
                    transform.Transform(webConfig, File.ReadAllText(configDelta.FullName));
                }
            }
            if (connectionStrings.Exists)
            {
                foreach (var configDelta in deltas.Where(file => FileTypes.ConfigDelta.IsType(file)).Where(file => file.Name.ToLowerInvariant().StartsWith("connectionstrings")))
                {
                    transform.Transform(connectionStrings, File.ReadAllText(configDelta.FullName));
                }
            }
        }

        public void CopyLicenseFileToDataFolder(BuildLibraryFile license, DataFolder dataFolder, FileInfo licenseConfigFile)
        {
            Log.As.Info("Copying license file '{0}'...", license.File.Name);

            var targetLicenseFileName = dataFolder.Directory.CombineTo<FileInfo>("license.xml");

            File.Copy(license.File.FullName, targetLicenseFileName.FullName, true);
            var licenseConfig = string.Format(WebsiteResource.LicenseFileFormat, targetLicenseFileName.Name);
            licenseConfig.WriteToDisk(licenseConfigFile);
            Log.As.Info("License file copied to '{0}'", targetLicenseFileName.FullName);
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

            TheWww.OpenInBrowser(baseUrl.ToUri(_InstallerPath, _AdminLoginName));
        }

        public void OpenFrontend(string baseUrl)
        {
            Log.As.Info("Accessing site...");

            if (string.IsNullOrEmpty(baseUrl))
            {
                Log.As.Error("baseUrl is null or empty");
                return;
            }

            TheWww.OpenInBrowser(baseUrl.ToUri());
        }

        public void InstallRuntimeServices(WebsiteFolder websiteFolder)
        {
            Log.As.Info("Installing runtime services...");

            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);

            runtimeServicesFolder.CreateIfNotExists();

            WebsiteResource.InstallPackageService.WriteToDir(runtimeServicesFolder, _InstallPackageServiceName);
            WebsiteResource.InstallPackageStatusService.WriteToDir(runtimeServicesFolder, _InstallPackageStatusName);
            WebsiteResource.DeserializeItems.WriteToDir(runtimeServicesFolder, _DeserializeItemsName);

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
            modules = modules.ToList();

            if (modules.Any() == false)
                return;

            //warm up site to make sure run time service is up and running
            WakeUpSite(baseUrl);
            Log.As.Info("Installing packages...");

            foreach (var module in modules)
            {
                foreach (var package in module.Directory.GetFiles(FileTypes.SitecorePackage))
                {
                    this.InstallPackage(baseUrl, package);
                }
                foreach (var update in module.Directory.GetFiles(FileTypes.SitecoreUpdate))
                {
                    this.InstallPackage(baseUrl, update);
                }
            }
        }

        private void InstallPackage(string baseUrl, FileInfo package)
        {
            var packageName = HttpUtility.UrlEncode(package.Name);
            Log.As.Info("Installing '{0}'...", HttpUtility.UrlDecode(packageName));

            const string installFormatPattern = "Action={0}&PackageName={1}";

            var callingUri = baseUrl.ToUri(_InstallerPath, _InstallPackageServiceName, "?" + string.Format(installFormatPattern, "Install", packageName));
            this.ExecuteInstallPackageAction(callingUri);

            Log.As.Info("Executing post installation steps for '{0}'...", HttpUtility.UrlDecode(packageName));

            callingUri = baseUrl.ToUri(_InstallerPath, _InstallPackageServiceName, "?" + string.Format(installFormatPattern, "PostInstall", packageName));
            this.ExecuteInstallPackageAction(callingUri);

            Log.As.Info("'{0}' is installed", package);
        }

        public void DeserializeItems(string baseUrl)
        {
            Log.As.Info("Deserializing items...");
            var callingUri = baseUrl.ToUri(_InstallerPath, _DeserializeItemsName);
            TheWww.CallUrl(callingUri);
        }

        public void ExecutePostInstallSteps(string baseUrl, DirectoryInfo websiteFolder)
        {
            //warm up site to make sure run time service is up and running
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_InstallerPath);
            WebsiteResource.PostInstallService.WriteToDir(runtimeServicesFolder, _PostInstallServiceName);
            WakeUpSite(baseUrl);
            Log.As.Info("Executing post install steps...");
            var callingUri = baseUrl.ToUri(_InstallerPath, _PostInstallServiceName);
            TheWww.CallUrl(callingUri);
        }

        public void WakeUpSite(string siteBaseUrl)
        {
            Log.As.Info("Waking up site...");
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
                    Log.As.Error("Faild to install {0}", url);
                    return;
                }
                Task.WaitAll(Task.Delay(1000));
            }
            while (response.StatusCode != HttpStatusCode.OK && response.StatusDescription.StartsWith("Done") == false);
        }
    }
}
