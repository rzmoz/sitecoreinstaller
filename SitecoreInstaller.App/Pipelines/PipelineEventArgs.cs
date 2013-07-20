namespace SitecoreInstaller.App.Pipelines
{
  using System;

  public class PipelineEventArgs : EventArgs
  {
    public ProjectSettings ProjectSettings { get; set; }
  }
}
