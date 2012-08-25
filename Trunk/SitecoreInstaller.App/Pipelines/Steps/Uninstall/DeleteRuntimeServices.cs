using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DeleteRuntimeServices : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Website.DeleteRuntimeServices(Services.AppSettings.WebsiteFolders.WebSiteFolder);
        }
    }
}
