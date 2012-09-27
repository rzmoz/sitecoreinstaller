using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.Website
{
    using SitecoreInstaller.Domain.BuildLibrary;

    public interface IWebsiteService
    {
        void SetDataFolder(DirectoryInfo dataFolder, FileInfo dataFolderConfigFile);
        void CopySitecoreToProjectfolder(WebsiteFolders websiteWebsiteFolders, BuildLibraryDirectory sitecore);
        void CopyModulesToWebsite(DirectoryInfo projectFolder, WebsiteFolders websiteWebsiteFolders, IEnumerable<BuildLibraryDirectory> modules);
        void CopyLicenseFileToDataFolder(BuildLibraryFile license, DirectoryInfo dataFolder, FileInfo licenseConfigFile);
        void OpenSitecore(string baseUrl, DirectoryInfo websiteFolder);
        void OpenFrontend(string baseUrl);
        void InstallRuntimeServices(DirectoryInfo websiteFolder);
        void DeleteRuntimeServices(DirectoryInfo websiteFolder);
        void InstallPackages(string baseUrl, IEnumerable<BuildLibraryDirectory> modules);
        void ExecutePostInstallSteps(string baseUrl);
        void WakeUpSite(string siteBaseUrl);
        void WarmUpSite(string siteBaseUrl);

        void CreateWffmConfigFile(string connectionString, FileInfo wffmConfigFile);
    }
}
