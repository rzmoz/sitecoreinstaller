using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    using SitecoreInstaller.App.Pipelines.Preconditions;

    public class DeleteProject : Step
    {
        public DeleteProject()
        {
            AddPrecondition<CheckUserAcceptForDeleteProject>();
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Projects.DeleteProject(Services.ProjectSettings.Folders.ProjectFolder);
        }
    }
}
