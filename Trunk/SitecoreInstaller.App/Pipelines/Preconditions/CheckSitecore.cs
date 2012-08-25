using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckSitecore : Precondition
    {
        public CheckSitecore(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        public override bool Evaluate(object sender, EventArgs args)
        {
            if (GetAppSettings().UserSelections.SelectedSitecore != null)
                return true;

            ErrorMessage = "You haven't selected a Sitecore. Please add a Sitecore in preferences pane if you have none";
            return false;
        }
    }
}
