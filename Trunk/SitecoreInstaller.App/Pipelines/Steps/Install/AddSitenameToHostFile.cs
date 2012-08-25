using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AddSitenameToHostFile : Step
    {
        public AddSitenameToHostFile(AppSettings appSettings)
            : base(appSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.HostFile.AddHostName(AppSettings.IisSiteName);
        }
    }
}
