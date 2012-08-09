using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    using SitecoreInstaller.Framework.Diagnostics;

    public class PipelineEventArgs : EventArgs
    {
        public PipelineEventArgs(string pipelineName, PipelineStatus status, params LogEntry[] entries)
        {
            PipelineName = (pipelineName ?? string.Empty).Replace("Pipeline", string.Empty);
            Status = status;
            Messages = entries ?? Enumerable.Empty<LogEntry>();
        }

        public string PipelineName { get; private set; }
        public PipelineStatus Status { get; private set; }
        public IEnumerable<LogEntry> Messages { get; private set; }
    }
}
