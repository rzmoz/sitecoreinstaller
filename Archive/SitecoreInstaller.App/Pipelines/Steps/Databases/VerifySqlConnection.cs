namespace SitecoreInstaller.App.Pipelines.Steps.Databases
{
    public class VerifySqlConnection : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            args.ProjectSettings.Sql.TestConnection();
        }
    }
}
