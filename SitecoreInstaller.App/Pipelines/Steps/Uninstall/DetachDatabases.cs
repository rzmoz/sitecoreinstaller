using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    public class DetachDatabases : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            //we drop sql dbs if it's local
            if (args.ProjectSettings.Sql.InstallType == DbInstallType.Auto)
            {
                var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
                foreach (var sqlDatabase in databases)
                    sqlDatabase.Detach(args.ProjectSettings.Sql);
            }

            //we drop databases in mongo if it's local
            if (args.ProjectSettings.Mongo.InstallType == DbInstallType.Auto)
            {
                var connectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile;
                connectionStrings.InitFromFile();

                Services.Mongo.DropDatabases(connectionStrings);    
            }
        }
    }
}
