using System;
using CSharp.Basics.Sys;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class PipelineRunnerEngine
    {
        private static readonly object _syncRoot = new object();

        public PipelineRunnerEngine()
        {
            IsBusy = false;
        }

        public event EventHandler<PipelineInfoEventArgs> PipelineStarting;
        public event EventHandler<EventArgs> PipelineCompleted;

        public event EventHandler<PipelineInfoEventArgs> AllStepsExecuting;
        public event EventHandler<PipelineInfoEventArgs> AllStepsExecuted;

        public event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
        public event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

        public event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

        public bool IsBusy { get; private set; }

        public void RunPipeline(IPipelineRunner runner)
        {
            lock (_syncRoot)
            {
                if (IsBusy)
                    return; //we abort if worker is already busy
                IsBusy = true;
                runner.StepExecuting += StepExecuting;
                runner.StepExecuted += StepExecuted;
                runner.AllStepsExecuting += AllStepsExecuting;
                runner.AllStepsExecuted += AllStepsExecuted;
                runner.PreconditionNotMet += PreconditionNotMet;

                if (PipelineStarting != null)
                    PipelineStarting(null, new PipelineInfoEventArgs(runner.Pipeline));
                runner.ExecuateAllSteps();
                if (PipelineCompleted != null)
                    PipelineCompleted(null, EventArgs.Empty);
                IsBusy = false;
            }
        }
    }
}
