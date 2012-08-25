using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class InstallRuntimeServices : Step
    {
        public InstallRuntimeServices(AppSettings appSettings)
            : base(appSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Website.InstallRuntimeServices(AppSettings.WebsiteFolders.WebSiteFolder);
        }
    }
}
