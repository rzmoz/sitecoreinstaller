using SitecoreInstaller.App.Pipelines.Steps.DatabaseSettings;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.Domain.Pipelines;

  public class TestSqlSettingsPipeline : Pipeline<PipelineEventArgs>
  {
    public TestSqlSettingsPipeline()
    {
      AddStep<VerifySqlConnection>();
    }
  }
}
