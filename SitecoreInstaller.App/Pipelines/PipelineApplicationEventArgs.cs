using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Domain.Website;

namespace SitecoreInstaller.App.Pipelines
{
    public class PipelineApplicationEventArgs : PipelineEventArgs
    {
        public ProjectSettings ProjectSettings { get; set; }
    }
}
