using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  using SitecoreInstaller.Domain.Pipelines;

  public class CheckSqlConnection:Precondition
  {
    public override bool Evaluate(object sender, PreconditionEventArgs args)
    {
      if (Services.ProjectSettings.Sql.TestConnection())
        return true;
      ErrorMessage = "Sql settings are not properly set. Check under preferences";
      return false;
    }
  }
}
