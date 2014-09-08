using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp.Basics.Sys;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class PipelineRunner<T, TK> : IPipelineRunner
        where T : class,IPipeline
        where TK : PipelineEventArgs
    {
        public event EventHandler<PipelineInfoEventArgs> AllStepsExecuting;
        public event EventHandler<PipelineInfoEventArgs> AllStepsExecuted;

        public event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
        public event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

        public event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

        public IPipeline Pipeline { get; private set; }

        public IEnumerable<Func<TK, Task>> PreProcessors { get; private set; }

        public PipelineRunner(T pipeline, IEnumerable<Func<TK, Task>> preProcessors = null)
        {
            if (pipeline == null) throw new ArgumentNullException("pipeline");

            Log.As.Reset();
            PreProcessors = preProcessors ?? Enumerable.Empty<Func<TK, Task>>();
            Pipeline = pipeline;
        }

        public void ExecuateAllSteps()
        {
            if (Pipeline.Args.AbortPipeline)
            {
                Log.As.Info("Aborting pipeline: {0}", Pipeline.Args.AbortReason);
                Log.As.Flush();
                //we don't break completely out of this method as we still want to clean up listeners
            }
            else if (PreconditionsAreMet(Pipeline.Preconditions, Pipeline.Args))
            {
                if (AllStepsExecuting != null)
                    AllStepsExecuting(null, new PipelineInfoEventArgs(Pipeline));
                Log.As.Info("Executing pre processors");
                foreach (var preProcessor in PreProcessors)
                {
                    Task.WaitAll(preProcessor(Pipeline.Args as TK));
                }
                Log.As.Info("Pre processors executed");

                var elapsed = Profiler.This(InnerExecuteAllSteps, this, Pipeline.Args);
                Log.As.Profile(Pipeline.Name.ToString(), elapsed);

                Log.As.Flush();

                var issues = from entry in Log.As.Entries
                             where entry.LogType == LogType.Warning ||
                             entry.LogType == LogType.Error
                             select entry;

                if (AllStepsExecuted != null)
                    AllStepsExecuted(null, new PipelineInfoEventArgs(Pipeline, issues.ToArray()));
            }

            //we clear listeners here since we don't want old listeners to hang around
            StepExecuting = null;
            StepExecuted = null;
            AllStepsExecuting = null;
            AllStepsExecuted = null;
        }

        private bool PreconditionsAreMet(IEnumerable<IPrecondition> preconditions, PipelineEventArgs args)
        {
            foreach (var precondition in preconditions)
            {
                Log.As.Info("Evaluating precondition: {0}", precondition.Name.ActiveForm);
                if (precondition.Evaluate(this, args))
                {
                    Log.As.Info("Precondition met: {0}", precondition.Name.ActiveForm);
                }
                else
                {
                    Log.As.Error("Precondition NOT met: {0}", precondition.Name.ActiveForm);
                    if (string.IsNullOrEmpty(precondition.ErrorMessage) == false)
                        Log.As.Error(precondition.ErrorMessage);
                    if (PreconditionNotMet != null)
                        PreconditionNotMet(Pipeline, new GenericEventArgs<string>(precondition.ErrorMessage));
                    return false;
                }
            }

            return true;
        }

        private void InnerExecuteAllSteps(object sender, EventArgs e)
        {
            var args = e as PipelineEventArgs;
            if (args == null)
                throw new ArgumentException("e must be of type :" + typeof(PipelineEventArgs));

            var totalCount = Pipeline.Steps.Count();
            foreach (var step in Pipeline.Steps)
            {
                if (args.AbortPipeline)
                {
                    Log.As.Info("Aborting pipeline: {0}", args.AbortReason);
                    Log.As.Flush();
                    break;//we don't execute more steps if pipeline is to be aborted
                }

                var infoArgs = new PipelineStepInfoEventArgs(step.Order, totalCount, step.Name.ActiveForm);
                if (StepExecuting != null)
                    StepExecuting(step, infoArgs);

                if (PreconditionsAreMet(step.Preconditions, args))
                {
                    Log.As.Info(step.Name.ActiveForm);
                    var elapsed = Profiler.This(step.Invoke, sender, args);
                    Log.As.Profile(step.Name.ActiveForm, elapsed);
                }
                else
                    break;

                if (StepExecuted != null)
                    StepExecuted(step, infoArgs);
            }

            //we clear listeners here since we don't want old listeners to hang around
            StepExecuting = null;
            StepExecuted = null;
        }
    }
}
