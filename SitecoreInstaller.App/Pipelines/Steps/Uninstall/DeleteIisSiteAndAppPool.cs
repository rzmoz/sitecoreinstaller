using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
  public class DeleteIisSiteAndAppPool : Step<PipelineEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            Services.IisManagement.DeleteApplication(args.ProjectSettings.Iis.Name);
        }
    }
}
