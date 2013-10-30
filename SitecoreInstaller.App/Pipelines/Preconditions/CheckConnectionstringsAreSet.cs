using System;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckConnectionstringsAreSet : Precondition<PipelineApplicationEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
    {
      if (args.ProjectSettings.InstallType == InstallType.Full)
        return true;

      if (args.ProjectSettings.InstallType == InstallType.Client)
      {
        throw new NotImplementedException();
      }
      return true;
    }
  }
}
