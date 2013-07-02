using System.Linq;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class SaveProjectSettings : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      var projectConfig = Services.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile;

      projectConfig.Properties.Sitecore = Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore.ToString();
      projectConfig.Properties.License = Services.ProjectSettings.BuildLibrarySelections.SelectedLicense.ToString();
      projectConfig.Properties.Modules = Services.ProjectSettings.BuildLibrarySelections.SelectedModules.Select(module => module.ToString()).ToList();
      projectConfig.Save();

    }
  }
}
