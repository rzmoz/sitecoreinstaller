using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.Framework.IO;

    public class SaveAppSettings : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var appSettingsFileName = Services.AppSettings.WebsiteFolders.ProjectFolder.Combine(new FileInfo(AppConstants.AppSettingsConfigFileName));
            
        }
    }
}
