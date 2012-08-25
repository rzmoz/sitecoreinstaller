using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AddSitenameToHostFile : Step
    {
        public AddSitenameToHostFile(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.HostFile.AddHostName(AppSettings.IisSiteName);
        }
    }
}
