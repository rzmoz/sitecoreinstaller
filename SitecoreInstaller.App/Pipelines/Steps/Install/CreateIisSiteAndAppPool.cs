using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CreateIisSiteAndAppPool : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.IisManagement.CreateApplication(args.ProjectSettings.Iis, args.ProjectSettings.ProjectFolder.Website.Directory, args.ProjectSettings.ProjectFolder.IisLogFiles);
        }
    }
}
