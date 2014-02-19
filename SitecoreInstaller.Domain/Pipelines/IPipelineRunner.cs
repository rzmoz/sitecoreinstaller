using System;
using CSharp.Basics.Sys;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IPipelineRunner
    {
        event EventHandler<PipelineInfoEventArgs> AllStepsExecuting;
        event EventHandler<PipelineInfoEventArgs> AllStepsExecuted;

        event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
        event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

        event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

        void ExecuateAllSteps(object sender, EventArgs e);
        IPipeline Pipeline { get; }
    }
}
