using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using CSharp.Basics.Sys;
using CSharp.Basics.Sys.Tasks;
using CSharp.Basics.IO;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IOx;
using SitecoreInstaller.Framework.Web;

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
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);
            WebsiteResource.AdminLogin.WriteToDisk(runtimeServicesFolder, _adminLoginName);

            TheWww.OpenInBrowser(baseUrl.ToUri(_installerPath, _adminLoginName));
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

            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);

            runtimeServicesFolder.CreateIfNotExists();

            WebsiteResource.InstallPackageService.WriteToDisk(runtimeServicesFolder, _installPackageServiceName);
            WebsiteResource.InstallPackageStatusService.WriteToDisk(runtimeServicesFolder, _installPackageStatusName);
            WebsiteResource.DeserializeItems.WriteToDisk(runtimeServicesFolder, _deserializeItemsName);
            WebsiteResource.PublishSite.WriteToDisk(runtimeServicesFolder, _publishSiteName);

            Log.As.Info("Runtime services installed");
        }

        public void DeleteRuntimeServices(DirectoryInfo websiteFolder)
        {
            //delete runtime services
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);

            if (runtimeServicesFolder.Exists == false)
            {
                Log.As.Debug("Runtime services not found. Aborting...");
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
            Log.As.Info("Installing packages...");

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
            Log.As.Info("Installing packages...");

            foreach (var standAloneScPackage in standAloneScPackages)
            {
                if (standAloneScPackage.File.IsSitecorePackage())
                    InstallPackage(baseUrl, standAloneScPackage.File);
            }
        }

        private void InstallPackage(string baseUrl, FileInfo package)
        {
            var packageName = HttpUtility.UrlEncode(package.Name);
            Log.As.Info("Installing '{0}'...", HttpUtility.UrlDecode(packageName));

            const string installFormatPattern = "Action={0}&PackageName={1}";

            var callingUri = baseUrl.ToUri(_installerPath, _installPackageServiceName, "?" + string.Format(installFormatPattern, "Install", packageName));
            ExecuteInstallPackageAction(callingUri);

            Log.As.Info("Executing post installation steps for '{0}'...", HttpUtility.UrlDecode(packageName));

            callingUri = baseUrl.ToUri(_installerPath, _installPackageServiceName, "?" + string.Format(installFormatPattern, "PostInstall", packageName));
            ExecuteInstallPackageAction(callingUri);

            Log.As.Info("'{0}' is installed", package);
        }

        public void PublishSite(string baseUrl, PublishType publishType = PublishType.Full)
        {
            WakeUpSite(baseUrl);
            Log.As.Info("Publishing site: {0}...", publishType);
            var callingUri = baseUrl.ToUri(_installerPath, _publishSiteName);
            TheWww.CallUrl(callingUri);
        }

        public void DeserializeItems(string baseUrl)
        {
            Log.As.Info("Deserializing items...");
            var callingUri = baseUrl.ToUri(_installerPath, _deserializeItemsName);
            TheWww.CallUrl(callingUri);
        }

        public void ExecutePostInstallSteps(string baseUrl, DirectoryInfo websiteFolder)
        {
            //warm up site to make sure run time service is up and running
            var runtimeServicesFolder = websiteFolder.CombineTo<DirectoryInfo>(_installerPath);
            WebsiteResource.PostInstallService.WriteToDisk(runtimeServicesFolder, _postInstallServiceName);
            WakeUpSite(baseUrl);
            Log.As.Info("Executing post install steps...");
            var callingUri = baseUrl.ToUri(_installerPath, _postInstallServiceName);
            TheWww.CallUrl(callingUri);
        }

        public void WakeUpSite(string siteBaseUrl)
        {
            Log.As.Info("Waking up site...");
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
            .WithPing(() => Log.As.Debug("Status code: '{0}' | Status description: '{1}'", response.StatusCode, response.StatusDescription))
            .Until(() => response.StatusCode == HttpStatusCode.OK || response.StatusDescription.StartsWith("Done"), 20.Minutes(), 10);

            if (!succeeded)
            {
                Log.As.Error("Failed to install {0}", url);
            }
        }
    }
}
