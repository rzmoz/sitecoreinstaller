using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CreateIisSiteAndAppPool : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.IisManagement.CreateApplication(Services.AppSettings.AppPool, Services.AppSettings.WebsiteFolders.WebSiteFolder, Services.AppSettings.WebsiteFolders.IisLogFilesFolder);
        }
    }
}
