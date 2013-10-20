using SitecoreInstaller.App.Pipelines.Steps.DatabaseSettings;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  public class TestSqlSettingsPipeline : Pipeline<PipelineEventArgs>
  {
    public TestSqlSettingsPipeline()
    {
      AddStep<VerifySqlConnection>();
    }
  }
}
