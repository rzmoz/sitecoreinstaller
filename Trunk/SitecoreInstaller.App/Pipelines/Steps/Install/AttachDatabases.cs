using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AttachDatabases : Step
    {
        public AttachDatabases(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var databases = Services.Sql.GetDatabases(AppSettings.WebsiteFolders.DatabaseFolder, AppSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Attach(AppSettings.Sql);
        }
    }
}
