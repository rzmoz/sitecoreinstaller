using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckConnectionstringsManuallyUpdated : IPrecondition
    {
        public bool Evaluate(object sender, PreconditionEventArgs args)
        {
            return Services.Dialogs.UserAccept(
                    "Please update connectionstrings.config and choose yes when done");
        }

        public string ErrorMessage
        {
            get { return ""; }
        }
    }
}
