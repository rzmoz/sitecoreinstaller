using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckUserAcceptForDeleteProject : Precondition
    {
        public override bool Evaluate(object sender, PreconditionEventArgs args)
        {
            if (args.Dialogs == Dialogs.Off)
                return true;
            return !Services.Dialogs.UserAccept(
                    "Do you want to keep '{0}'? (Saying no will delete it forever!)",
                    Services.ProjectSettings.ProjectName);
        }
    }
}
