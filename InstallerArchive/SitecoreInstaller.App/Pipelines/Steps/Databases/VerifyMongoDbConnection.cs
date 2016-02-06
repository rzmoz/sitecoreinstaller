namespace SitecoreInstaller.App.Pipelines.Steps.Databases
{
    public class VerifyMongoDbConnection : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            args.ProjectSettings.Mongo.TestConnection();
        }
    }
}
