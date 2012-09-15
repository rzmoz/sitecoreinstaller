using System.IO;
using System.Linq;

using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Domain.Projects;
using SitecoreInstaller.Domain.WebServer;
using SitecoreInstaller.Domain.Website;
using SitecoreInstaller.Framework.Configuration;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.App
{
    using System;

    using SitecoreInstaller.App.Pipelines;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.Pipelines;

    //TODO: replace with Unity some day maybe?
    public static class Services
    {
        static Services()
        {
            Pipelines = new PipelineManager();
            Website = new WebsiteService();
            Dialogs = new Dialogs();
            IisManagement = new IisManagementService();
            HostFile = new HostFileService();
            PipelineWorker = new PipelineWorker();
            AppSettings = new AppSettings();
            SourceManifests = new SourceManifestRepository(AppConstants.SourcesConfigFileName);
        }

        public static void Init()
        {
            CheckPreferencesOverride();

            var localBuildLibrary = new WindowsFileSystemSource(string.Empty) { Parameters = UserSettings.Default.LocalBuildLibrary };
            if (BuildLibrary == null)
                BuildLibrary = new LocalSourceRepository(localBuildLibrary, SourceManifests.All().Select(Create));
            else
                ((LocalSourceRepository)BuildLibrary).Init(localBuildLibrary, SourceManifests.All().Select(Create));

            BuildLibrary.Update();


            Projects = new ProjectsService(UserSettings.Default.ProjectsFolder);

            Sql = new SqlService();
        }

        private static void CheckPreferencesOverride()
        {
            if (File.Exists(AppConstants.PreferencesOverrideConfigFileName) == false)
                return;

            dynamic preferencesOverrideConfigFile = new ConfigFile(AppConstants.PreferencesOverrideConfigFileName);

            UserSettings.Default.ProjectsFolder = UserSettings.Default.ProjectsFolder.TrySet((string)preferencesOverrideConfigFile.ProjectsFolder);
            UserSettings.Default.LocalBuildLibrary = UserSettings.Default.LocalBuildLibrary.TrySet((string)preferencesOverrideConfigFile.LocalBuildLibrary);
            UserSettings.Default.IisSitePostfix = UserSettings.Default.IisSitePostfix.TrySet((string)preferencesOverrideConfigFile.IisSitePostfix);
            UserSettings.Default.SqlInstanceName = UserSettings.Default.SqlInstanceName.TrySet((string)preferencesOverrideConfigFile.SqlInstanceName);
            UserSettings.Default.SqlLogin = UserSettings.Default.SqlLogin.TrySet((string)preferencesOverrideConfigFile.SqlLogin);
            UserSettings.Default.SqlPassword = UserSettings.Default.SqlPassword.TrySet((string)preferencesOverrideConfigFile.SqlPassword);
            UserSettings.Default.PromptForUserSettings = UserSettings.Default.PromptForUserSettings.TrySet((string)preferencesOverrideConfigFile.PromptForUserSettings);
            UserSettings.Default.LicenseExpirationPeriodInDays = UserSettings.Default.LicenseExpirationPeriodInDays.TrySet((string)preferencesOverrideConfigFile.LicenseExpirationPeriodInDays);
        }

        private static ISource Create(SourceManifest sourceManifest)
        {
            var sourceFactory = new SourceFactory();
            var sourceInstance = sourceFactory.Create<ISource>(sourceManifest.Type, sourceManifest.Name);
            sourceInstance.Parameters = sourceManifest.Parameters;
            return sourceInstance;
        }

        private static SourceManifestRepository SourceManifests { get; set; }

        public static AppSettings AppSettings { get; set; }
        public static PipelineManager Pipelines { get; private set; }
        public static ISourceRepository BuildLibrary { get; set; }
        public static IProjectsService Projects { get; set; }
        public static IWebsiteService Website { get; set; }
        public static IHostFileService HostFile { get; set; }
        public static IIisManagementService IisManagement { get; set; }
        public static ISqlService Sql { get; set; }
        public static Dialogs Dialogs { get; set; }
        public static PipelineWorker PipelineWorker { get; set; }
    }
}
