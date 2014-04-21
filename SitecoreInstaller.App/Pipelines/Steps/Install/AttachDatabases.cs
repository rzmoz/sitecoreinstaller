using SitecoreInstaller.Domain;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AttachDatabases : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            //we attach sql databases if it's local
            if (args.ProjectSettings.Sql.InstallType == DbInstallType.Auto)
            {
                var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
                foreach (var sqlDatabase in databases)
                {
                    Log.ToApp.Info("Attaching {0}...", sqlDatabase.Name);
                    sqlDatabase.Attach(args.ProjectSettings.Sql);
                }    
            }

            //mongo databases are created on the fly
        }
    }
}
