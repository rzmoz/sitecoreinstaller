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
    public class PipelineRunner<T> : IPipelineRunner where T : class,IPipeline
    {
        public event EventHandler<PipelineEventArgs> AllStepsExecuting;
        public event EventHandler<PipelineEventArgs> AllStepsExecuted;

        public event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
        public event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

        public event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

        public T Pipeline { get; private set; }

        public PipelineRunner(T pipeline, string executeAllText = "")
        {
            if (pipeline == null) throw new ArgumentNullException("pipeline");

            Log.As.Clear();
            ExecuteAllText = executeAllText;
            Pipeline = pipeline;
            pipeline.IsInUiMode = true;
        }
        public string ExecuteAllText { get; private set; }

        public void ExecuateAllSteps(object sender, EventArgs e)
        {
            if (AllStepsPreconditionsAreMet(Pipeline.Preconditions))
            {
                if (AllStepsExecuting != null)
                    AllStepsExecuting(sender, new PipelineEventArgs(Pipeline.Name, PipelineStatus.NoProblems));

                var elapsed = Profiler.This(InnerExecuteAllSteps, sender, e);
                Log.As.Profile(Pipeline.GetType().Name, elapsed);

                Log.As.Flush();

                var warnings = from entry in Log.As.Entries
                               where entry.LogType == LogType.Warning
                               select entry;

                var errors = from entry in Log.As.Entries
                             where entry.LogType == LogType.Error
                             select entry;

                var pipelineStatus = PipelineStatus.NoProblems;
                if (warnings.Any())
                    pipelineStatus = PipelineStatus.Warnings;
                if (errors.Any())
                    pipelineStatus = PipelineStatus.Errors;

                var results = warnings.Concat(errors);

                if (AllStepsExecuted != null)
                    AllStepsExecuted(sender, new PipelineEventArgs(Pipeline.Name, pipelineStatus, results.ToArray()));
            }

            //we clear listeners here since we don't want old listeners to hang around
            StepExecuting = null;
            StepExecuted = null;
            AllStepsExecuting = null;
            AllStepsExecuted = null;
        }

        private bool AllStepsPreconditionsAreMet(IEnumerable<IPrecondition> preconditions)
        {
            Log.As.Info("Evaluating pipeline preconditions for {0}", Pipeline.Name);

            foreach (var precondition in preconditions)
            {
                if (precondition.Evaluate(this, new PreconditionEventArgs()))
                {
                    Log.As.Info("Precondition met: {0}", precondition.GetType().Name);
                }
                else
                {
                    if (string.IsNullOrEmpty(precondition.ErrorMessage) == false)
                        Log.As.Error(precondition.ErrorMessage);
                    if (Pipeline.IsInUiMode && PreconditionNotMet != null)
                        PreconditionNotMet(Pipeline, new GenericEventArgs<string>(precondition.ErrorMessage));
                    return false;
                }
            }

            return true;
        }

        private void InnerExecuteAllSteps(object sender, EventArgs e)
        {
            var totalCount = Pipeline.Steps.Count();
            foreach (var step in Pipeline.Steps)
            {
                var args = new PipelineStepInfoEventArgs(step.Order, totalCount, step.GetType().Name);
                if (StepExecuting != null)
                    StepExecuting(step, args);

                
                if (AllStepsPreconditionsAreMet(step.Preconditions))
                {
                    var elapsed = Profiler.This(step.Invoke, sender, e);
                    Log.As.Profile(step.GetType().Name, elapsed);    
                }
                else
                    break;

                if (StepExecuted != null)
                    StepExecuted(step, args);
            }

            //we clear listeners here since we don't want old listeners to hang around
            StepExecuting = null;
            StepExecuted = null;
        }
    }
}
