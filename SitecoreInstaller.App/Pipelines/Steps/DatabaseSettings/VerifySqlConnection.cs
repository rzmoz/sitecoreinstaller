namespace SitecoreInstaller.App.Pipelines.Steps.DatabaseSettings
{
  public class VerifySqlConnection : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      args.ProjectSettings.Sql.TestConnection();
    }
  }
}
