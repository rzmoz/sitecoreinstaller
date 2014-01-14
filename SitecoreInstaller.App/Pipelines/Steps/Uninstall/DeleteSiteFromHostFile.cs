using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DeleteSiteFromHostFile : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.IisManagement.HostFile.RemoveHostName(args.ProjectSettings.Iis.Url);
        }
    }
}
