using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
    public class CleanProjectForArchiving : Step
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            Services.Projects.CleanProjectForArchiving(args.ProjectSettings.ProjectFolder);
        }
    }
}
