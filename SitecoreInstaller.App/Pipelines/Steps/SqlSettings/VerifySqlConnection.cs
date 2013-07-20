using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.SqlSettings
{
  public class VerifySqlConnection : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      args.ProjectSettings.Sql.TestConnection();
    }
  }
}
