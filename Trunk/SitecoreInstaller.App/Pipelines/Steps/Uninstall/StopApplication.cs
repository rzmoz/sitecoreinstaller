using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    using SitecoreInstaller.Domain.Pipelines;

    public class StopApplication : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.IisManagement.StopApplication(Services.ProjectSettings.Iis.Name);
        }
    }
}
