using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.App.Pipelines.Preconditions;

    public class CreateProjectFolder : Step
    {
        public CreateProjectFolder()
        {
            AddPrecondition<CheckProjectDoesNotExist>();
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Projects.CreateProject(Services.ProjectSettings.ProjectFolder.Directory);
        }
    }
}
