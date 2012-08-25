using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class PipelineStepEventArgs : EventArgs
    {
        public PipelineStepEventArgs(Action getAppSettings)
        {
            GetAppSettings = getAppSettings;
        }

        public Action GetAppSettings;
    }
}
