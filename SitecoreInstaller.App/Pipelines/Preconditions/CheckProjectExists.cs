using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using System.IO;

    using SitecoreInstaller.Domain.Pipelines;

    public class CheckProjectExists : Precondition
    {
      public override bool InnerEvaluate(object sender, StepEventArgs args)
        {
            if (Directory.Exists(args.ProjectSettings.ProjectFolder.FullName))
                return true;

            ErrorMessage = string.Format("Project '{0}' doesn't exist.\r\n\r\nLocation: {1}", args.ProjectSettings.ProjectName, args.ProjectSettings.ProjectFolder);
            return false;
        }
    }
}
