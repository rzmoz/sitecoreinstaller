using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DeleteProject : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            if (!Services.Dialogs.UserAccept("Do you want to keep '{0}'? (Saying no will delete it forever!)", Services.AppSettings.ProjectName.Value))
                Services.Website.DeleteProjectFolder(Services.AppSettings.WebsiteFolders.ProjectFolder);
        }
    }
}
