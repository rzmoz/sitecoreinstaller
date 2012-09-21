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
            if(Services.ProjectSettings.InstallType == InstallType.Full)
                return true;
            Services.Dialogs.Information("Please update connectionstrings.config and press ok to continue");
            return true;
        }

        public string ErrorMessage
        {
            get { return ""; }
        }
    }
}
