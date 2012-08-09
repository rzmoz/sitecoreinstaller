using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IPipelineRunner
    {
        event EventHandler<PipelineEventArgs> AllStepsExecuting;
        event EventHandler<PipelineEventArgs> AllStepsExecuted;

        event EventHandler<PipelineStepEventArgs> StepExecuting;
        event EventHandler<PipelineStepEventArgs> StepExecuted;

        string ExecuteAllText { get; }
        void ExecuateAllSteps(object sender, EventArgs e);
    }
}
