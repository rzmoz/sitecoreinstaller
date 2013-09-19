using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.Website
{
    using BuildLibrary;

    public interface IWebsiteService
    {
        void SetDataFolder(DataFolder dataFolder, FileInfo dataFolderConfigFile);
        void CopySitecoreToProjectfolder(ProjectFolder projectFolder, BuildLibraryDirectory sitecore, InstallType installType);
        void CopyModulesToWebsite(ProjectFolder projectFolder, BuildLibraryDirectory module, InstallType installType);
        void CopyLicenseFileToDataFolder(BuildLibraryFile license, DataFolder dataFolder, FileInfo licenseConfigFile);
        void OpenSitecore(string baseUrl, DirectoryInfo websiteFolder);
        void OpenFrontend(string baseUrl);
        void InstallRuntimeServices(WebsiteFolder websiteFolder);
        void DeleteRuntimeServices(DirectoryInfo websiteFolder);
        void InstallPackages(string baseUrl, IEnumerable<BuildLibraryDirectory> modules);
        void DeserializeItems(string baseUrl);
        void ExecutePostInstallSteps(string baseUrl, DirectoryInfo websiteFolder);
        void WakeUpSite(string siteBaseUrl);

        void CreateWffmConfigFile(string connectionString, FileInfo wffmConfigFile);
    }
}
