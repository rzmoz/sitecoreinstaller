using System;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckConnectionstringsAreSet : Precondition<PipelineEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineEventArgs args)
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
