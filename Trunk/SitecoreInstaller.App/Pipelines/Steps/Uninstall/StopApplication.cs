using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class StopApplication : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.IisManagement.StopApplication(Services.AppSettings.Iis.Name);
        }
    }
}
