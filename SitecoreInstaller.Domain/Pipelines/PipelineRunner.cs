using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Domain.Pipelines
{
  /// <summary>
  /// Use as decorator for classes that have methods with StepAttributes
  /// </summary>
  /// <typeparam name="T"></typeparam>
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
    public IEnumerable<Action<TK>> PreProcessors { get; private set; }
    public PipelineRunner(T pipeline, IEnumerable<Action<TK>> preProcessors = null, string executeAllText = "")
    {
      if (pipeline == null) throw new ArgumentNullException("pipeline");

      Log.ToApp.Reset();
      ExecuteAllText = executeAllText;
      PreProcessors = preProcessors ?? Enumerable.Empty<Action<TK>>();
      Pipeline = pipeline;
    }

    public string ExecuteAllText { get; private set; }


    public void ExecuateAllSteps(object sender, DoWorkEventArgs e)
    {
      if (Pipeline.Args.AbortPipeline)
      {
        Log.ToApp.Info("Aborting pipeline: {0}", Pipeline.Args.AbortReason);
        Log.ToApp.Flush();
        //we don't break completely out of this method as we still want to clean up listeners
      }
      else if (PreconditionsAreMet(Pipeline.Preconditions, Pipeline.Args))
      {
        if (AllStepsExecuting != null)
          AllStepsExecuting(sender, new PipelineInfoEventArgs(Pipeline));
        Log.ToApp.Info("Executing pre processors");
        foreach (var preProcessor in PreProcessors)
        {
          preProcessor(Pipeline.Args as TK);
        }
        Log.ToApp.Info("Pre processors executed");

        var elapsed = Profiler.This(InnerExecuteAllSteps, this, Pipeline.Args);
        Log.ToApp.Profile(Pipeline.Name.ToString(), elapsed);

        Log.ToApp.Flush();

        var issues = from entry in Log.ToApp.Entries
                     where entry.LogType == LogType.Warning ||
                     entry.LogType == LogType.Error
                     select entry;

        if (AllStepsExecuted != null)
          AllStepsExecuted(sender, new PipelineInfoEventArgs(Pipeline, issues.ToArray()));
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
        Log.ToApp.Info("Evaluating precondition: {0}", precondition.Name.ActiveForm);
        if (precondition.Evaluate(this, args))
        {
          Log.ToApp.Info("Precondition met: {0}", precondition.Name.ActiveForm);
        }
        else
        {
          Log.ToApp.Error("Precondition NOT met: {0}", precondition.Name.ActiveForm);
          if (string.IsNullOrEmpty(precondition.ErrorMessage) == false)
            Log.ToApp.Error(precondition.ErrorMessage);
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
          Log.ToApp.Info("Aborting pipeline: {0}", args.AbortReason);
          Log.ToApp.Flush();
          break;//we don't execute more steps if pipeline is to be aborted
        }

        var infoArgs = new PipelineStepInfoEventArgs(step.Order, totalCount, step.Name.ActiveForm);
        if (StepExecuting != null)
          StepExecuting(step, infoArgs);

        if (PreconditionsAreMet(step.Preconditions, args))
        {
          Log.ToApp.Info(step.Name.ActiveForm);
          var elapsed = Profiler.This(step.Invoke, sender, args);
          Log.ToApp.Profile(step.Name.ActiveForm, elapsed);
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
