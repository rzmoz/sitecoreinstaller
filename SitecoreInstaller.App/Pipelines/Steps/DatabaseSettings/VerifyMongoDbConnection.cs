namespace SitecoreInstaller.App.Pipelines.Steps.DatabaseSettings
{
  public class VerifyMongoDbConnection : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      args.ProjectSettings.Mongo.TestConnection();
    }
  }
}
