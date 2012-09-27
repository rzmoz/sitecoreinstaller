using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class InstallRuntimeServices : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Website.InstallRuntimeServices(Services.ProjectSettings.Folders.WebSiteFolder);
        }
    }
}
