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

    public class UpdateAppSettings : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var appSettingsFileName = Services.AppSettings.WebsiteFolders.ProjectFolder.Combine(new FileInfo(AppConstants.AppSettingsConfigFileName));
            dynamic appConfig = new ConfigFile(appSettingsFileName);
            if (appSettingsFileName.Exists)
            {
                Services.AppSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseSettingsString(appConfig.Sitecore);
            }
            else
            {
                Resources.EmptyConfigFile.WriteToDisk(appSettingsFileName);
                appConfig.Sitecore = Services.AppSettings.BuildLibrarySelections.SelectedSitecore.ToSettingsString();
            }
        }
    }
}
