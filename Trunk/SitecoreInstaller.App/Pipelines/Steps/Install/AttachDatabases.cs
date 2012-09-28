using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.Framework.Diagnostics;

    public class AttachDatabases : Step
    {
        public AttachDatabases()
        {
            AddPrecondition<CheckConnectionstringsManuallyUpdated>();
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            if (Services.ProjectSettings.InstallType == InstallType.Client)
                return;

            Log.As.Info("Attaching databases...");
            var databases = Services.Sql.GetDatabases(Services.ProjectSettings.ProjectFolder.Databases, Services.ProjectSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Attach(Services.ProjectSettings.Sql);
        }
    }
}
