using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    public class AttachDatabases : Step
    {


        public AttachDatabases()
        {
            AddPrecondition<CheckConnectionstringsManuallyUpdated>();
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            if (Services.AppSettings.InstallType == InstallType.Client)
                return;

            var databases = Services.Sql.GetDatabases(Services.AppSettings.WebsiteFolders.DatabaseFolder, Services.AppSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Attach(Services.AppSettings.Sql);
        }
    }
}
