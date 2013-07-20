using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.Domain.Pipelines;

    public class DeleteProject : Step
    {
        public DeleteProject()
        {
            AddPrecondition<CheckUserAcceptForDeleteProject>();
        }

        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.Projects.DeleteProject(args.ProjectSettings.ProjectFolder.Directory);
        }
    }
}
