using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class InstallRuntimeServices : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      Services.Website.InstallRuntimeServices(args.ProjectSettings.ProjectFolder.Website);
    }
  }
}
