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
            Services.IisManagement.CreateApplication(Services.ProjectSettings.Iis, Services.ProjectSettings.Folders.WebSiteFolder, Services.ProjectSettings.Folders.IisLogFilesFolder);
        }
    }
}
