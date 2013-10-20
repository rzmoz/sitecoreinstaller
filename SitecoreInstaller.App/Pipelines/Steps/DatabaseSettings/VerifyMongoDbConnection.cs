namespace SitecoreInstaller.App.Pipelines.Steps.DatabaseSettings
{
  public class VerifyMongoDbConnection : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      args.ProjectSettings.Mongo.TestConnection();
    }
  }
}
