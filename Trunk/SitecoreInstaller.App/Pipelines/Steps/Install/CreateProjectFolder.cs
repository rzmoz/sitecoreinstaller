using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CreateProjectFolder : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Website.CreateTargetFolders(Services.AppSettings.WebsiteFolders);
        }
    }
}
