using System.Linq;
using SitecoreInstaller.Domain.Projects;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SaveProjectSettings : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var projectConfig = args.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile;

            projectConfig.Properties.Sitecore = args.ProjectSettings.BuildLibrarySelections.SelectedSitecore.ToString();
            projectConfig.Properties.License = args.ProjectSettings.BuildLibrarySelections.SelectedLicense.ToString();
            projectConfig.Properties.Modules = args.ProjectSettings.BuildLibrarySelections.SelectedModules.Select(module => module.ToString()).ToList();
            projectConfig.Properties.SqlInstallType = args.ProjectSettings.Sql.InstallType;
            projectConfig.Properties.MongoInstallType = args.ProjectSettings.Mongo.InstallType;
            projectConfig.Save();
        }
    }
}
