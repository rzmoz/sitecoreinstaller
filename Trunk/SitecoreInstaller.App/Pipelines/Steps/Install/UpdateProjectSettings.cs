using System;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Framework.Configuration;
    using SitecoreInstaller.Framework.IO;
    using SitecoreInstaller.Framework.System;

    public class UpdateProjectSettings : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var projectSettingsFileName = Services.ProjectSettings.Folders.ProjectFolder.Combine(new FileInfo(AppConstants.ProjectSettingsConfigFileName));
            dynamic projectConfig = new DynamicConfigFile(projectSettingsFileName);
            if (projectSettingsFileName.Exists)
            {
                Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseString(projectConfig.Sitecore);
                Services.ProjectSettings.InstallType = ((string)projectConfig.InstallType).ParseToEnumValue<InstallType>();
            }
            else
            {
                Resources.EmptyConfigFile.WriteToDisk(projectSettingsFileName);
                projectConfig.Sitecore = Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore.ToString();
                projectConfig.InstallType = Services.ProjectSettings.InstallType.ToString();
            }
        }
    }
}
