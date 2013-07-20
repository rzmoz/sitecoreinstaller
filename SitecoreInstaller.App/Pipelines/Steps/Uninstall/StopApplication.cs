using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    using SitecoreInstaller.Domain.Pipelines;

  public class StopApplication : Step<PipelineEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            Services.IisManagement.StopApplication(args.ProjectSettings.Iis.Name);
        }
    }
}
