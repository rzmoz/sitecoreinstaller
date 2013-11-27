﻿using System;
using System.IO;
using System.Linq;

using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Domain.Projects;
using SitecoreInstaller.Domain.WebServer;
using SitecoreInstaller.Domain.Website;
using SitecoreInstaller.Framework.Configuration;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App
{

  public static class Services
  {
    static Services()
    {
      Pipelines = new PipelineService();
      PowerShellScripts = new PowerShellScriptService();
      Website = new WebsiteService();
      IisManagement = new IisManagementService();
      PipelineWorker = new PipelineWorker();
      SourceManifests = new SourceManifestRepository(new FileInfo(AppConstants.SourcesConfigFileName));
      SourceManifests.ManifestsUpdated += InitBuildLibrary;
      Sql = new SqlService();
      Mongo = new MongoService();
    }

    public static void Init()
    {
      //init before initializing build library
      SourceManifests.UpdateLocal();

      InitBuildLibrary(null, EventArgs.Empty);

      InitProjects();
    }

    private static void InitBuildLibrary(object sender, EventArgs e)
    {
      Log.This.Debug("Initializing Build library");
      var localBuildLibrary = new WindowsFileSystemSource(string.Empty)
      {
        Parameters = UserPreferences.Properties.LocalBuildLibrary
      };
      if (BuildLibrary == null)
      {
        BuildLibrary = new LocalSourceRepository(localBuildLibrary, SourceManifests.Enabled.Select(Create));
      }
      else
      {
        ((LocalSourceRepository)BuildLibrary).Init(localBuildLibrary, SourceManifests.Enabled.Select(Create));
      }

      BuildLibrary.Update();
    }

    public static void LoadUserPreferences()
    {
      UserPreferences = new ConfigFile<UserPreferencesConfig>(new FileInfo(AppConstants.UserPreferencesFileName));
      UserPreferences.Updated += UserPreferences_Updated;

      if (File.Exists(AppConstants.UserPreferencesFileName) == false)
        return;

      new BuildLibraryFolders(UserPreferences.Properties.LocalBuildLibrary).Create();
      new DirectoryInfo(UserPreferences.Properties.ProjectsFolder).Create();
    }

    static void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
    {
      InitProjects();
      InitBuildLibrary(sender, e);
    }

    private static void InitProjects()
    {
      Log.This.Info("Initiallizing Projects");
      Projects = new ProjectsService(UserPreferences.Properties.ProjectsFolder);
    }

    private static ISource Create(SourceManifest sourceManifest)
    {
      var sourceFactory = new SourceFactory();
      var sourceInstance = sourceFactory.Create<ISource>(sourceManifest.Type, sourceManifest.Name);
      sourceInstance.Parameters = sourceManifest.Parameters;
      sourceInstance.Enabled = sourceManifest.Enabled;
      return sourceInstance;
    }

    public static SourceManifestRepository SourceManifests { get; set; }
    public static ConfigFile<UserPreferencesConfig> UserPreferences { get; private set; }

    public static PipelineService Pipelines { get; private set; }
    public static PowerShellScriptService PowerShellScripts { get; private set; }
    public static ISourceRepository BuildLibrary { get; private set; }
    public static ProjectsService Projects { get; private set; }
    public static WebsiteService Website { get; private set; }
    public static IIisManagementService IisManagement { get; private set; }
    public static SqlService Sql { get; private set; }
    public static MongoService Mongo { get; private set; }
    public static PipelineWorker PipelineWorker { get; private set; }
  }
}
