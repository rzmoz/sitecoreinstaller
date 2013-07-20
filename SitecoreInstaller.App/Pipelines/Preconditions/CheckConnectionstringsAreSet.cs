﻿using System;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  using SitecoreInstaller.Domain;

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
