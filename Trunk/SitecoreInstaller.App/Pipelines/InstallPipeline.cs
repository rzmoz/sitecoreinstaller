using System;
using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Framework.Xml;

namespace SitecoreInstaller.App.Pipelines
{
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Linq;

    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.Website;
    using SitecoreInstaller.Framework.Diagnostics;

    public class InstallPipeline : SitecoreInstallerPipeline
    {
        public InstallPipeline(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        public override void Init()
        {
            base.Init();
            var preconditions = new List<IPrecondition>
                {
                    new CheckSitecore(AppSettings),
                    new CheckLicense(AppSettings),
                    new CheckWritePermissionToHostFile(AppSettings),
                    new CheckProjectExixts(AppSettings)
                };

            preconditions.AddRange(Preconditions);
            Preconditions = preconditions;
        }

        [Step(1)]
        public void CreateProjectFolder(object sender, EventArgs e)
        {
            Services.Website.CreateTargetFolders(AppSettings.WebsiteFolders);
        }

        [Step(2)]
        public void CopySitecore(object sender, EventArgs e)
        {
            var selectedSitecore = Services.BuildLibrary.Get(AppSettings.UserSelections.SelectedSitecore, SourceType.Sitecore);
            if (selectedSitecore is BuildLibraryDirectory == false)
                throw new DirectoryNotFoundException("selected Sitecore was not of type BuildLibraryDirectory. Was:" + selectedSitecore.GetType());
            Services.Website.CopySitecoreToProjectfolder(AppSettings.WebsiteFolders, selectedSitecore as BuildLibraryDirectory);
        }
        [Step(3)]
        public void CopyLicenseFile(object sender, EventArgs e)
        {
            var license = Services.BuildLibrary.Get(AppSettings.UserSelections.SelectedLicense, SourceType.License);
            if (license is BuildLibraryFile == false)
                throw new DirectoryNotFoundException("license was not of type BuildLibraryFile. Was:" + license.GetType());
            Services.Website.CopyLicenseFileToDataFolder(license as BuildLibraryFile, AppSettings.WebsiteFolders.DataFolder, AppSettings.LicenseConfigFile);
        }
        [Step(4)]
        public void SetDataFolder(object sender, EventArgs e)
        {
            Services.Website.SetDataFolder(AppSettings.WebsiteFolders.DataFolder, AppSettings.DataFolderConfigFile);
        }
        [Step(5)]
        public void CopyModuleFiles(object sender, EventArgs e)
        {
            var selectedModules = from module in AppSettings.UserSelections.SelectedModules
                                  select Services.BuildLibrary.Get(module, SourceType.Module);
            Services.Website.CopyModulesToWebsite(AppSettings.WebsiteFolders.ProjectFolder, AppSettings.WebsiteFolders, selectedModules.OfType<BuildLibraryDirectory>());
        }
        [Step(6)]
        public void SetConnectionStrings(object sender, EventArgs e)
        {
            var connectionStrings = new ConnectionStringsFile(AppSettings.ConnectionStringsConfigFile);

            connectionStrings.Init();
            var existingConnectionStringNames = connectionStrings.Select(entry => entry.Name);
            var connectionStringsDelta = Services.Sql.GenerateConnectionStringsDelta(AppSettings.Sql, AppSettings.WebsiteFolders.DatabaseFolder, AppSettings.ProjectName.Value, existingConnectionStringNames);
            var transform = new XmlTransform(connectionStrings.File, connectionStringsDelta);
            transform.Run();

            //WFFM Sql-Dataprovider connection string set
            connectionStrings.Init();

            var webFormsConnectionString = connectionStrings["webforms"];

            if (webFormsConnectionString == null)
                return;

            if (File.Exists(AppSettings.WffmConfigFile.FullName) == false)
                return;

            var formsConfigFile = new WffmConfigFile(AppSettings.WffmConfigFile);
            if (formsConfigFile.DataProviderType == DataProviderType.Sql)
                Services.Website.CreateWffmConfigFile(webFormsConnectionString.ConnectionString, AppSettings.WffmSqlDataproviderConfigFile);
        }

        [Step(7)]
        public void AttachDatabases(object sender, EventArgs e)
        {
            var databases = Services.Sql.GetDatabases(AppSettings.WebsiteFolders.DatabaseFolder, AppSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Attach(AppSettings.Sql);
        }

        [Step(8)]
        public void AddSiteNameToHostFile(object sender, EventArgs e)
        {
            Services.HostFile.AddHostName(AppSettings.IisSiteName);
        }
        [Step(9)]
        public void CreateIisSiteAndAppPool(object sender, EventArgs e)
        {
            Services.IisManagement.CreateApplication(AppSettings.AppPool, AppSettings.WebsiteFolders.WebSiteFolder, AppSettings.WebsiteFolders.IisLogFilesFolder);
        }
        [Step(10)]
        public void InstallRuntimeServices(object sender, EventArgs e)
        {
            Services.Website.InstallRuntimeServices(AppSettings.WebsiteFolders.WebSiteFolder);
        }
        [Step(11)]
        public void InstallPackages(object sender, EventArgs e)
        {
            var selectedModules = Services.BuildLibrary.Get(AppSettings.UserSelections.SelectedModules, SourceType.Module);
            Services.Website.InstallPackages(AppSettings.IisSiteName, selectedModules.OfType<BuildLibraryDirectory>());
        }
        [Step(12)]
        public void ExecutePostInstallSteps(object sender, EventArgs e)
        {
            Services.Website.ExecutePostInstallSteps(AppSettings.IisSiteName);
        }
    }
}
