using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.Domain.Pipelines;

    public class CreateProjectFolder : Step
    {
        public CreateProjectFolder()
        {
            AddPrecondition<CheckProjectDoesNotExist>();
        }

        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.Projects.CreateProject(args.ProjectSettings.ProjectFolder.Directory);
        }
    }
}
