using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.Domain;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    public class AttachDatabases : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs  args)
        {
            if (Services.ProjectSettings.InstallType == InstallType.Client)
                return;

            Log.As.Info("Attaching databases...");
            var databases = Services.Sql.GetDatabases(Services.ProjectSettings.ProjectFolder.Databases, Services.ProjectSettings.ProjectName);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Attach(Services.ProjectSettings.Sql);
        }
    }
}
