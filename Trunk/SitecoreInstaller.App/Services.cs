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
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.Pipelines;

  //TODO: replace with Unity some day maybe?
  public static class Services
  {
    static Services()
    {
      Pipelines = new PipelineService();
      Website = new WebsiteService();
      Dialogs = new UiDialogs();
      IisManagement = new IisManagementService();
      PipelineWorker = new PipelineWorker();
      ProjectSettings = new ProjectSettings();
      SourceManifests = new SourceManifestRepository(new FileInfo(AppConstants.SourcesConfigFileName));
    }

    public static void Init()
    {
      LoadUserPreferences();

      //init before initializing build library
      SourceManifests.Init();

      var localBuildLibrary = new WindowsFileSystemSource(string.Empty) { Parameters = UserPreferences.Properties.LocalBuildLibrary };
      if (BuildLibrary == null)
        BuildLibrary = new LocalSourceRepository(localBuildLibrary, SourceManifests.All().Select(Create));
      else
        ((LocalSourceRepository)BuildLibrary).Init(localBuildLibrary, SourceManifests.All().Select(Create));

      BuildLibrary.Update();

      Projects = new ProjectsService(UserPreferences.Properties.ProjectsFolder);

      Sql = new SqlService();
    }

    private static void LoadUserPreferences()
    {
      UserPreferences = new ConfigFile<UserPreferencesConfig>(new FileInfo(AppConstants.UserPreferencesFileName));

      if (File.Exists(AppConstants.UserPreferencesFileName) == false)
        return;

      new BuildLibraryFolders(UserPreferences.Properties.LocalBuildLibrary).Create();
      new DirectoryInfo(UserPreferences.Properties.ProjectsFolder).Create();
    }

    private static ISource Create(SourceManifest sourceManifest)
    {
      var sourceFactory = new SourceFactory();
      var sourceInstance = sourceFactory.Create<ISource>(sourceManifest.Type, sourceManifest.Name);
      sourceInstance.Parameters = sourceManifest.Parameters;
      return sourceInstance;
    }

    private static SourceManifestRepository SourceManifests { get; set; }
    public static ConfigFile<UserPreferencesConfig> UserPreferences { get; private set; }

    public static ProjectSettings ProjectSettings { get; set; }
    public static PipelineService Pipelines { get; private set; }
    public static ISourceRepository BuildLibrary { get; set; }
    public static IProjectsService Projects { get; set; }
    public static IWebsiteService Website { get; set; }
    public static IIisManagementService IisManagement { get; set; }
    public static ISqlService Sql { get; set; }
    public static UiDialogs Dialogs { get; set; }
    public static PipelineWorker PipelineWorker { get; set; }
  }
}
