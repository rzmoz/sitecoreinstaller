using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.SqlSettings
{
  public class VerifySqlConnection : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      Services.ProjectSettings.Sql.TestConnection();
    }
  }
}
