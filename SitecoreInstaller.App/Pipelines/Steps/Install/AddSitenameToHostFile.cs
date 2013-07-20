using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.Domain.Pipelines;

    public class AddSitenameToHostFile : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.IisManagement.HostFile.AddHostName(args.ProjectSettings.Iis.Url);
        }
    }
}
