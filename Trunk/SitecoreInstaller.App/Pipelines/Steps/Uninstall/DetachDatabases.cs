using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DetachDatabases : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            if (Services.ProjectSettings.InstallType == InstallType.Client)
                return;

            var databases = Services.Sql.GetDatabases(Services.ProjectSettings.WebsiteFolders.DatabaseFolder, Services.ProjectSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Detach(Services.ProjectSettings.Sql);
        }
    }
}
