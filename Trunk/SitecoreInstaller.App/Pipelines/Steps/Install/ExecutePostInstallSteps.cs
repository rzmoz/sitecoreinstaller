using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class ExecutePostInstallSteps : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.Website.ExecutePostInstallSteps(Services.ProjectSettings.Iis.Url, Services.ProjectSettings.ProjectFolder.Website.Directory);
        }
    }
}
