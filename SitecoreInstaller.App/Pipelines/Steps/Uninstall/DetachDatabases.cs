using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
  public class DetachDatabases : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      if (args.ProjectSettings.InstallType == InstallType.Client)
        return;

      var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
      foreach (var sqlDatabase in databases)
        sqlDatabase.Detach(args.ProjectSettings.Sql);
      
      var connectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile;
      connectionStrings.InitFromFile();

      Services.Mongo.DropDatabases(connectionStrings);
    }
  }
}
