using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  using SitecoreInstaller.Domain;
  using SitecoreInstaller.Domain.Pipelines;
  
  public class CheckConnectionstringsAreSet : Precondition
  {
    public override bool Evaluate(object sender, PreconditionEventArgs args)
    {
      if (Services.ProjectSettings.InstallType == InstallType.Full)
        return true;

      if (Services.ProjectSettings.InstallType == InstallType.Client)
      {
        throw new NotImplementedException();
      }
      return true;
    }
  }
}
