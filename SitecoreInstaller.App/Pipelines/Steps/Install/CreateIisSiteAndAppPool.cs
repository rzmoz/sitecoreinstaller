using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CreateIisSiteAndAppPool : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.IisManagement.CreateApplication(Services.ProjectSettings.Iis, Services.ProjectSettings.ProjectFolder.Website.Directory, Services.ProjectSettings.ProjectFolder.IisLogFiles);
        }
    }
}
