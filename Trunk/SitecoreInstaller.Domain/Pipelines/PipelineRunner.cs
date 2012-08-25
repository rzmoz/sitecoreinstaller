﻿using System;
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
    public class PipelineRunner<T> : IPipelineRunner where T : class,IPipeline
    {
        private readonly Profiler _execuateAllStepsProfiler;

        public event EventHandler<PipelineEventArgs> AllStepsExecuting;
        public event EventHandler<PipelineEventArgs> AllStepsExecuted;

        public event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
        public event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

        public event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

        public PipelinePreProcessor<T> Processor { get; private set; }

        public PipelineRunner(T pipeline, string executeAllText = "")
        {
            if (pipeline == null) throw new ArgumentNullException("pipeline");

            Log.It.Clear();
            ExecuteAllText = executeAllText;
            Processor = new PipelinePreProcessor<T>(pipeline);
            Processor.Init();
            Processor.IsInUiMode = true;
            _execuateAllStepsProfiler = new Profiler("Executing all steps in " + Processor.Pipeline.GetType().GetStepText(), InnerExecuteAllSteps);
            _execuateAllStepsProfiler.ActionProfiled += Log.It.Profile;
        }
        public string ExecuteAllText { get; private set; }

        public void ExecuateAllSteps(object sender, EventArgs e)
        {
            if (AllStepsPreconditionsAreMet())
            {
                if (AllStepsExecuting != null)
                    AllStepsExecuting(sender, new PipelineEventArgs(Processor.PipelineName, PipelineStatus.NoErrors));

                _execuateAllStepsProfiler.Run(sender, e);

                Log.It.FlushBuffer();

                var results = from entry in Log.It.Entries
                              where entry.LogType == LogType.Warning || entry.LogType == LogType.Error
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
            Log.It.Info("Evaluating pipeline preconditions for {0}", Processor.PipelineName);

            foreach (var precondition in Processor.Pipeline.Preconditions)
            {
                if (precondition.Evaluate(this, EventArgs.Empty))
                {
                    Log.It.Info("Precondition met: {0}", precondition.GetType().Name);
                }
                else
                {
                    if (Processor.IsInUiMode && PreconditionNotMet != null)
                        PreconditionNotMet(Processor.Pipeline, new GenericEventArgs<string>(precondition.ErrorMessage));
                    return false;
                }
            }

            return true;
        }

        private void InnerExecuteAllSteps(object sender, EventArgs e)
        {
            var totalCount = Processor.Steps.Count();
            foreach (var installStep in Processor.Steps)
            {
                var args = new PipelineStepInfoEventArgs(installStep.Order, totalCount, installStep.Text);
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
