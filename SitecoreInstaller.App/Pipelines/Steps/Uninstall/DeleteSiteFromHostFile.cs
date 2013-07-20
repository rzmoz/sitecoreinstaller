using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    using SitecoreInstaller.Domain.Pipelines;

    public class DeleteSiteFromHostFile : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.IisManagement.HostFile.RemoveHostName(args.ProjectSettings.Iis.Url);
        }
    }
}
