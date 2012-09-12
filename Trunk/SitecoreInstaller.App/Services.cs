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
            SourceManifests = new SourceManifestRepository(ApplicationConstants.SourcesConfigFileName);
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
            if (File.Exists(ApplicationConstants.PreferencesOverrideConfigFileName) == false)
                return;
            var configuration = new ConfigFileConfigurationRepository();
            configuration.Load(ApplicationConstants.PreferencesOverrideConfigFileName);
            if (string.IsNullOrEmpty(configuration["ProjectsFolder"]) == false)
                UserSettings.Default.ProjectsFolder = configuration["ProjectsFolder"];
            if (string.IsNullOrEmpty(configuration["LocalBuildLibrary"]) == false)
                UserSettings.Default.LocalBuildLibrary = configuration["LocalBuildLibrary"];
            if (string.IsNullOrEmpty(configuration["IisSitePostfix"]) == false)
                UserSettings.Default.IisSitePostfix = configuration["IisSitePostfix"];
            if (string.IsNullOrEmpty(configuration["SqlInstanceName"]) == false)
                UserSettings.Default.SqlInstanceName = configuration["SqlInstanceName"];
            if (string.IsNullOrEmpty(configuration["SqlLogin"]) == false)
                UserSettings.Default.SqlLogin = configuration["SqlLogin"];
            if (string.IsNullOrEmpty(configuration["SqlPassword"]) == false)
                UserSettings.Default.SqlPassword = configuration["SqlPassword"];
            if (string.IsNullOrEmpty(configuration["PromptForUserSettings"]) == false)
                UserSettings.Default.PromptForUserSettings = Convert.ToBoolean(configuration["PromptForUserSettings"]);
            if (string.IsNullOrEmpty(configuration["LicenseExpirationPeriodInDays"]) == false)
                UserSettings.Default.LicenseExpirationPeriodInDays = Convert.ToInt32(configuration["LicenseExpirationPeriodInDays"]);
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
