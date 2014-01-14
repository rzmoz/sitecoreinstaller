using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AddSitenameToHostFile : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.IisManagement.HostFile.AddHostName(args.ProjectSettings.Iis.Url);
        }
    }
}
