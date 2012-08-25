using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DetachDatabases : Step
    {
        public DetachDatabases(AppSettings appSettings)
            : base(appSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var databases = Services.Sql.GetDatabases(AppSettings.WebsiteFolders.DatabaseFolder, AppSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Detach(AppSettings.Sql);
        }
    }
}
