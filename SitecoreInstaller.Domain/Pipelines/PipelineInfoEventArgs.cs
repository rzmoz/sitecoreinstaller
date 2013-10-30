using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Pipelines
{
  public class PipelineInfoEventArgs : EventArgs
  {
    public PipelineInfoEventArgs(IPipeline pipeline, params LogEntry[] entries)
    {
      PipelineName = pipeline.Name.ToString();
      Messages = entries ?? Enumerable.Empty<LogEntry>();
    }

    public string PipelineName { get; private set; }
    public IEnumerable<LogEntry> Messages { get; private set; }
  }
}
