using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckSitecore : Precondition
    {
        public override bool Evaluate(object sender, PreconditionEventArgs args)
        {
            if (Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore != null)
                return true;

            ErrorMessage = "You haven't selected a Sitecore. Please add a Sitecore in preferences pane if you have none";
            return false;
        }
    }
}
