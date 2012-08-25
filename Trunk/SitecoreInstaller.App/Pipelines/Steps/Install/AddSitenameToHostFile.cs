using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AddSitenameToHostFile : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.HostFile.AddHostName(Services.AppSettings.IisSiteName);
        }
    }
}
