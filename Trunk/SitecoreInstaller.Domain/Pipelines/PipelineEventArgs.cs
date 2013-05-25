using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
  using SitecoreInstaller.Framework.Diagnostics;

  public class PipelineEventArgs : EventArgs
  {
    public PipelineEventArgs(IPipeline pipeline, params LogEntry[] entries)
    {
      PipelineName = pipeline.Name.ToString();
      Messages = entries ?? Enumerable.Empty<LogEntry>();
    }

    public string PipelineName { get; private set; }
    public IEnumerable<LogEntry> Messages { get; private set; }
  }
}
