using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AttachDatabases : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var databases = Services.Sql.GetDatabases(Services.AppSettings.WebsiteFolders.DatabaseFolder, Services.AppSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Attach(Services.AppSettings.Sql);
        }
    }
}
