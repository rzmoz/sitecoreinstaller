using System.Linq;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class UpdateProjectSettings : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      var projectConfig = Services.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile;

      if (Services.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile.Exists)
      {
        projectConfig.Load();
        Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseString(projectConfig.Properties.Sitecore);
        Services.ProjectSettings.BuildLibrarySelections.SelectedLicense = SourceEntry.ParseString(projectConfig.Properties.License);
        Services.ProjectSettings.BuildLibrarySelections.SelectedModules = projectConfig.Properties.Modules.Select(SourceEntry.ParseString);
      }
      else
      {
        projectConfig.Properties.Sitecore = Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore.ToString();
        projectConfig.Properties.License = Services.ProjectSettings.BuildLibrarySelections.SelectedLicense.ToString();
        projectConfig.Properties.Modules = Services.ProjectSettings.BuildLibrarySelections.SelectedModules.Select(module => module.ToString()).ToList();
        projectConfig.Save();
      }
    }
  }
}
