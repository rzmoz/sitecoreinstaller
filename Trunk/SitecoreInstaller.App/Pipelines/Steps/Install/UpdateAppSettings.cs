using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Framework.Configuration;
    using SitecoreInstaller.Framework.IO;
    using SitecoreInstaller.Framework.System;

    public class UpdateAppSettings : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var appSettingsFileName = Services.AppSettings.WebsiteFolders.ProjectFolder.Combine(new FileInfo(AppConstants.AppSettingsConfigFileName));
            dynamic appConfig = new ConfigFile(appSettingsFileName);
            if (appSettingsFileName.Exists)
            {
                Services.AppSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseString(appConfig.Sitecore);
                Services.AppSettings.InstallType = ((string)appConfig.InstallType).ParseToEnumValue<InstallType>();
            }
            else
            {
                Resources.EmptyConfigFile.WriteToDisk(appSettingsFileName);
                appConfig.Sitecore = Services.AppSettings.BuildLibrarySelections.SelectedSitecore.ToString();
                appConfig.InstallType = Services.AppSettings.InstallType.ToString();
            }
        }
    }
}
