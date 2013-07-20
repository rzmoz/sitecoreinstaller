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
            if (args.ProjectSettings.InstallType == InstallType.Client)
                return;

            var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
            foreach (var sqlDatabase in databases)
            {
              Log.This.Info("Attaching {0}...", sqlDatabase.Name);
              sqlDatabase.Attach(args.ProjectSettings.Sql);
            }
        }
    }
}
