using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SitecoreInstaller.Domain.Pipelines
{
    using System.Threading;

    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;

    /// <summary>
    /// Use as decorator for classes that have methods with StepAttributes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PipelineRunner<T> : IPipelineRunner where T : IPipeline
    {
        private readonly ILog _log;
        private readonly Profiler _execuateAllStepsProfiler;

        public event EventHandler<PipelineEventArgs> AllStepsExecuting;
        public event EventHandler<PipelineEventArgs> AllStepsExecuted;

        public event EventHandler<PipelineStepEventArgs> StepExecuting;
        public event EventHandler<PipelineStepEventArgs> StepExecuted;

        public PipelineProcessor<T> Processor { get; private set; }

        public PipelineRunner(T pipeline, ILog log, string executeAllText = "")
        {
            if (pipeline == null) throw new ArgumentNullException("pipeline");
            if (log == null) throw new ArgumentNullException("log");
            _log = log;
            _log.Clear();
            ExecuteAllText = executeAllText;
            Processor = new PipelineProcessor<T>(pipeline, _log);
            Processor.Init();
            Processor.IsInUiMode = true;
            _execuateAllStepsProfiler = new Profiler("Executing all steps in " + Processor.Pipeline.GetType().GetStepText(), InnerExecuteAllSteps);
            _execuateAllStepsProfiler.ActionProfiled += _log.Profile;
        }
        public string ExecuteAllText { get; private set; }

        public void ExecuateAllSteps(object sender, EventArgs e)
        {
            if (AllStepsPreconditionsAreMet())
            {
                if (AllStepsExecuting != null)
                    AllStepsExecuting(sender, new PipelineEventArgs(Processor.PipelineName, PipelineStatus.NoErrors));

                _execuateAllStepsProfiler.Run(sender, e);

                _log.FlushBuffer();

                var results = from entry in _log.Entries
                              where entry.MessageType == MessageType.Warning || entry.MessageType == MessageType.Error
                              select entry;

                var pipelineStatus = PipelineStatus.NoErrors;
                if (results.Any())
                    pipelineStatus = PipelineStatus.SoftErrors;

                if (AllStepsExecuted != null)
                    AllStepsExecuted(sender, new PipelineEventArgs(Processor.PipelineName, pipelineStatus, results.ToArray()));
            }

            //we clear listeners here since we don't want old listeners to hang around
            StepExecuting = null;
            StepExecuted = null;
            AllStepsExecuting = null;
            AllStepsExecuted = null;
        }

        private bool AllStepsPreconditionsAreMet()
        {
            return Processor.Preconditions.All(precondition => precondition(Processor.PipelineName));
        }

        private void InnerExecuteAllSteps(object sender, EventArgs e)
        {
            var totalCount = Processor.Steps.Count();
            foreach (var installStep in Processor.Steps)
            {
                var args = new PipelineStepEventArgs(installStep.Order, totalCount, installStep.Text);
                if (StepExecuting != null)
                    StepExecuting(installStep, args);
                installStep.Invoke(sender, e);
                if (StepExecuted != null)
                    StepExecuted(installStep, args);
            }

            //we clear listeners here since we don't want old listeners to hang around
            StepExecuting = null;
            StepExecuted = null;
        }
    }
}
