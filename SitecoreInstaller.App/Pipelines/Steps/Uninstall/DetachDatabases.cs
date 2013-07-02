using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    using SitecoreInstaller.Domain;
    using SitecoreInstaller.Domain.Pipelines;

    public class DetachDatabases : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            if (Services.ProjectSettings.InstallType == InstallType.Client)
                return;

            var databases = Services.Sql.GetDatabases(Services.ProjectSettings.ProjectFolder.Databases, Services.ProjectSettings.ProjectName);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Detach(Services.ProjectSettings.Sql);
        }
    }
}
