using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SetDataFolder : Step
    {
        public SetDataFolder(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Website.SetDataFolder(AppSettings.WebsiteFolders.DataFolder, AppSettings.DataFolderConfigFile);
        }
    }
}
