using System;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  public class PipelineApplicationEventArgs : PipelineEventArgs
  {
    public ProjectSettings ProjectSettings { get; set; }
  }
}
