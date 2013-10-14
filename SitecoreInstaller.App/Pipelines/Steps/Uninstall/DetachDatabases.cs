namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
  using Domain;

  public class DetachDatabases : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      if (args.ProjectSettings.InstallType == InstallType.Client)
        return;

      var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
      foreach (var sqlDatabase in databases)
        sqlDatabase.Detach(args.ProjectSettings.Sql);


      var connectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile;
      connectionStrings.InitFromFile();

      var mongoDatabases = Services.Mongo.GetDatabases(connectionStrings);
      foreach (var mongoDatabase in mongoDatabases)
      {
        mongoDatabase.Drop();
      }
    }
  }
}
