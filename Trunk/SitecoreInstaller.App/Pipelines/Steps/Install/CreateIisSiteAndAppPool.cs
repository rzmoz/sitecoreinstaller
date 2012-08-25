using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CreateIisSiteAndAppPool : Step
    {
        public CreateIisSiteAndAppPool(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.IisManagement.CreateApplication(AppSettings.AppPool, AppSettings.WebsiteFolders.WebSiteFolder, AppSettings.WebsiteFolders.IisLogFilesFolder);
        }
    }
}
