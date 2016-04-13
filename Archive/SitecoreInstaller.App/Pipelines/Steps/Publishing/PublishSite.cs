using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.App.Pipelines.Steps.Publishing
{
    public class PublishSite : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.Website.InstallRuntimeServices(args.ProjectSettings.ProjectFolder.Website);
            Services.Website.PublishSite(args.ProjectSettings.Iis.Url);
        }
    }
}
