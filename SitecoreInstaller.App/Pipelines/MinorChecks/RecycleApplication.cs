using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.App.Pipelines.Steps;

namespace SitecoreInstaller.App.Pipelines.MinorChecks
{
    public class RecycleApplication : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.IisManagement.RecycleApplication(args.ProjectSettings.Iis.Name);
        }
    }
}
