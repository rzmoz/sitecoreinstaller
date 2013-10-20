using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class AddSitenameToHostFile : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      Services.IisManagement.HostFile.AddHostName(args.ProjectSettings.Iis.Url);
    }
  }
}
