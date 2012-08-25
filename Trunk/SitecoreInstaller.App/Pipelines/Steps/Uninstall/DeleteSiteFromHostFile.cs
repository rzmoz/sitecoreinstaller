using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DeleteSiteFromHostFile : Step
    {
        public DeleteSiteFromHostFile(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.HostFile.RemoveHostName(AppSettings.IisSiteName);
        }
    }
}
