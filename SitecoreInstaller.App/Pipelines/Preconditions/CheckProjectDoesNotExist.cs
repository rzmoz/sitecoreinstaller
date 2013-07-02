using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckProjectDoesNotExist : CheckProjectExists
    {
        public override bool Evaluate(object sender, PreconditionEventArgs args)
        {
            if (base.Evaluate(sender, args) == false)
                return true;

            ErrorMessage = string.Format("Project '{0}' already exists.\r\nPlease delete first or choose another project name for this installation.\r\n\r\nLocation: {1}", Services.ProjectSettings.ProjectName, Services.ProjectSettings.ProjectFolder);
            return false;
        }
    }
}
