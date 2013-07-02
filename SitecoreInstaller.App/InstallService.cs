using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SitecoreInstaller.Domain.Batch;
using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Messaging;
using SitecoreInstaller.Framework.Profiling;

namespace SitecoreInstaller.App
{
    public class InstallService : SitecoreInstallerService
    {
        [Step(1)]
        public void CreateProjectFolder(object sender, EventArgs e)
        {
            Services.Website.CreateProjectFolder(Services.AppSettings.ProjectFolder);
        }

        [Step(2)]
        public void CopySitecore(object sender, EventArgs e)
        {
            var selectedCms = Services.BuildLibrary.GetCms(Services.UserSelections.SelectedCmsVersion);
            Services.Website.CopySitecoreToProjectfolder(Services.AppSettings.WebSiteFolders, selectedCms);
        }
        [Step(3)]
        public void VerifyAndCreateTargetFolders(object sender, EventArgs e)
        {
            Services.Website.CreateWebSiteFolders(Services.AppSettings.WebSiteFolders);
        }
        [Step(4)]
        public void CopyLicenseFile(object sender, EventArgs e)
        {
            var license = Services.BuildLibrary.GetLicense(Services.UserSelections.SelectedLicense).CombineWithFile("license.xml");
            Services.Website.CopyLicenseFileToDataFolder(license, Services.AppSettings.WebSiteFolders.DataFolder);
        }
        [Step(5)]
        public void SetDataFolder(object sender, EventArgs e)
        {
            Services.Website.SetDataFolder(Services.AppSettings.WebSiteFolders.DataFolder, Services.AppSettings.DataFolderMode, Services.AppSettings.DataFolderConfigFile);
        }
        [Step(6)]
        public void CopyModuleFiles(object sender, EventArgs e)
        {
            var selectedModules = from module in Services.UserSelections.SelectedModules
                                  select Services.BuildLibrary.GetModule(module);
            Services.Website.CopyModulesToWebsite(Services.AppSettings.ProjectFolder, Services.AppSettings.WebSiteFolders, selectedModules);
        }
        [Step(7)]
        public void CreateConnectionStringsConfigFile(object sender, EventArgs e)
        {
            var connectionScriptConfigDocument = Services.Sql.GenerateConnectionStringsConfig(Services.AppSettings.Sql, Services.AppSettings.WebSiteFolders.DatabaseFolder, Services.AppSettings.ProjectName);
            Services.Website.SaveConnectionStringsConfigFileToConfigFolder(connectionScriptConfigDocument, Services.AppSettings.ConnectionStringsConfigFile);
        }
        [Step(8)]
        public void CreateSqlScripts(object sender, EventArgs e)
        {
            Services.Sql.CreateSqlScripts(Services.AppSettings.Sql, Services.AppSettings.ProjectName, Services.AppSettings.ProjectFolder, Services.AppSettings.WebSiteFolders.DatabaseFolder);
        }
        [Step(9)]
        public void AttachDatabases(object sender, EventArgs e)
        {
            Services.Sql.AttachDatabases(Services.AppSettings.AttachScriptPath, Services.AppSettings.Sql);
        }
        [Step(10)]
        public void MapDatabaseLogin(object sender, EventArgs e)
        {
            Services.Sql.MapDbLogin(Services.AppSettings.MapLoginScriptPath, Services.AppSettings.Sql);
        }
        [Step(11)]
        public void AddSiteNameToHostFile(object sender, EventArgs e)
        {
            Services.HostFile.AddHostName(Services.AppSettings.IisSiteName);
        }
        [Step(12)]
        public void CreateIisSiteAndAppPool(object sender, EventArgs e)
        {
            Services.IisManagement.CreateApplication(Services.AppSettings.AppPool, Services.AppSettings.WebSiteFolders.WebSiteFolder);
        }
        [Step(13)]
        public void InstallRuntimeServices(object sender, EventArgs e)
        {
            Services.Website.InstallRuntimeServices(Services.AppSettings.WebSiteFolders.WebSiteFolder);
        }
        [Step(14)]
        public void InstallPackages(object sender, EventArgs e)
        {
            Services.Website.InstallAllPackages(Services.AppSettings.IisSiteName);
        }
        [Step(15)]
        public void ExecuteSecretPostInstallSteps(object sender, EventArgs e)
        {
            Services.Website.ExecuteSecretPostInstallSteps(Services.AppSettings.IisSiteName);
        }
        [Step(16)]
        public void WarmUpSite(object sender, EventArgs e)
        {
            Services.Website.WarmUpSite(Services.AppSettings.IisSiteName);
        }
        [Step(17)]
        public void OpenSitecore(object sender, EventArgs e)
        {
            Services.Website.OpenSitecore(Services.AppSettings.IisSiteName, Services.AppSettings.WebSiteFolders.WebSiteFolder);
        }
    }
}
