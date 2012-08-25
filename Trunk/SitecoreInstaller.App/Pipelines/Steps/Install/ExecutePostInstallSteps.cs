using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class ExecutePostInstallSteps : Step
    {
        public ExecutePostInstallSteps(AppSettings appSettings)
            : base(appSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Website.ExecutePostInstallSteps(AppSettings.IisSiteName);
        }
    }
}
