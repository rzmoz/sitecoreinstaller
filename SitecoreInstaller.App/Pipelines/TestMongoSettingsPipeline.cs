using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.App.Pipelines.Steps.DatabaseSettings;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  public class TestMongoSettingsPipeline : Pipeline<PipelineEventArgs>
  {
    public TestMongoSettingsPipeline()
    {
      AddStep<VerifyMongoDbConnection>();
    }
  }
}
