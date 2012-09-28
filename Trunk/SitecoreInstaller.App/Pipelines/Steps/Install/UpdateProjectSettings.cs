using System;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Configuration;
    using SitecoreInstaller.Framework.IO;
    using SitecoreInstaller.Framework.System;

    public class UpdateProjectSettings : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            dynamic projectConfig = Services.ProjectSettings.ProjectFolder.ProjectSettingsconfigFile;
            if (Services.ProjectSettings.ProjectFolder.ProjectSettingsconfigFile.Exists)
            {
                Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseString(projectConfig.Sitecore);
                Services.ProjectSettings.InstallType = ((string)projectConfig.InstallType).ParseToEnumValue<InstallType>();
            }
            else
            {
                Resources.EmptyConfigFile.WriteToDisk(Services.ProjectSettings.ProjectFolder.ProjectSettingsconfigFile.Path);
                projectConfig.Sitecore = Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore.ToString();
                projectConfig.InstallType = Services.ProjectSettings.InstallType.ToString();
            }
        }
    }
}
