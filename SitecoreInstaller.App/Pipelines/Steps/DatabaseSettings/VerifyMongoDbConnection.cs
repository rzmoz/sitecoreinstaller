using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
