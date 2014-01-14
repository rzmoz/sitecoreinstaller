using SitecoreInstaller.Domain;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class AttachDatabases : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (args.ProjectSettings.InstallType == InstallType.Client)
                return;

            var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
            foreach (var sqlDatabase in databases)
            {
                Log.ToApp.Info("Attaching {0}...", sqlDatabase.Name);
                sqlDatabase.Attach(args.ProjectSettings.Sql);
            }
        }
    }
}
