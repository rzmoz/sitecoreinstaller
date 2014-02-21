using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Domain.Website;

namespace SitecoreInstaller.App.Pipelines
{
    public class PipelineApplicationEventArgs : PipelineEventArgs
    {
        public PipelineApplicationEventArgs()
        {
            SitecoreSettings = Enumerable.Empty<SitecoreSetting>();
        }

        public ProjectSettings ProjectSettings { get; set; }
        public IEnumerable<SitecoreSetting> SitecoreSettings { get; set; }
    }
}
