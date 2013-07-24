﻿using System.Linq;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class SaveProjectSettings : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      var projectConfig = args.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile;

      projectConfig.Properties.Sitecore = args.ProjectSettings.BuildLibrarySelections.SelectedSitecore.ToString();
      projectConfig.Properties.License = args.ProjectSettings.BuildLibrarySelections.SelectedLicense.ToString();
      projectConfig.Properties.Modules = args.ProjectSettings.BuildLibrarySelections.SelectedModules.Select(module => module.ToString()).ToList();
      projectConfig.Save();

    }
  }
}