namespace SitecoreInstaller.App.Pipelines.Steps.DatabaseSettings
{
  public class VerifySqlConnection : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      args.ProjectSettings.Sql.TestConnection();
    }
  }
}
