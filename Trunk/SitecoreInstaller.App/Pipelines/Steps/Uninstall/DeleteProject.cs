using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DeleteProject : Step
    {
        public DeleteProject(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            if (!Services.Dialogs.UserAccept("Do you want to keep '{0}'? (Saying no will delete it forever!)", AppSettings.ProjectName.Value))
                Services.Website.DeleteProjectFolder(AppSettings.WebsiteFolders.ProjectFolder);
        }
    }
}
