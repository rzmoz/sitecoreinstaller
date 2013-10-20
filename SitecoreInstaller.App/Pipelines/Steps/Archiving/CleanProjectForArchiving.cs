﻿namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
  public class CleanProjectForArchiving : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      Services.Projects.CleanProjectForArchiving(args.ProjectSettings.ProjectFolder);
    }
  }
}
