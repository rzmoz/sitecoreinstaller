using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IPipelineProcessor<out T> where T : IPipeline
    {
        T Pipeline { get; }
        bool IsInUiMode { get; set; }
        bool InitOnStepInvoke { get; set; }
        IEnumerable<ProfiledStep> Steps { get; }
    }
}
