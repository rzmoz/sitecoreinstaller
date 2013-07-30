namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Steps.SqlSettings;
  using SitecoreInstaller.Domain.Pipelines;

  public class TestSqlSettingsPipeline : Pipeline<PipelineEventArgs>
  {
    public TestSqlSettingsPipeline()
    {
      AddStep<VerifySqlConnection>();
    }
  }
}
