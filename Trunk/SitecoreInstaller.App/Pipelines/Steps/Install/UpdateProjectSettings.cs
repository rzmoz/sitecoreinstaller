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
            var projectSettingsFileName = Services.ProjectSettings.WebsiteFolders.ProjectFolder.Combine(new FileInfo(AppConstants.ProjectSettingsConfigFileName));
            dynamic appConfig = new ConfigFile(projectSettingsFileName);
            if (projectSettingsFileName.Exists)
            {
                Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseString(appConfig.Sitecore);
                Services.ProjectSettings.InstallType = ((string)appConfig.InstallType).ParseToEnumValue<InstallType>();
            }
            else
            {
                Resources.EmptyConfigFile.WriteToDisk(projectSettingsFileName);
                appConfig.Sitecore = Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore.ToString();
                appConfig.InstallType = Services.ProjectSettings.InstallType.ToString();
            }
        }
    }
}
