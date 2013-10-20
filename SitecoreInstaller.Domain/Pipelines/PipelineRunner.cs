using System;
using System.Collections.Generic;
using System.Linq;

namespace SitecoreInstaller.Domain.Pipelines
{
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Sys;

  /// <summary>
  /// Use as decorator for classes that have methods with StepAttributes
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class PipelineRunner<T, TK> : IPipelineRunner
    where T : class,IPipeline
    where TK : EventArgs
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

      Log.This.Reset();
      ExecuteAllText = executeAllText;
      PreProcessors = preProcessors ?? Enumerable.Empty<Action<TK>>();
      Pipeline = pipeline;
    }

    public string ExecuteAllText { get; private set; }


    public void ExecuateAllSteps(object sender, EventArgs e)
    {
      if (PreconditionsAreMet(Pipeline.Preconditions, Pipeline.Args))
      {
        if (AllStepsExecuting != null)
          AllStepsExecuting(sender, new PipelineInfoEventArgs(Pipeline));
        Log.This.Info("Executing pre processors");
        foreach (var preProcessor in PreProcessors)
        {
          preProcessor(Pipeline.Args as TK);
        }
        Log.This.Info("Pre processors executed");

        var elapsed = Profiler.This(InnerExecuteAllSteps, this, Pipeline.Args);
        Log.This.Profile(Pipeline.Name.ToString(), elapsed);

        Log.This.Flush();

        var issues = from entry in Log.This.Entries
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

    private bool PreconditionsAreMet(IEnumerable<IPrecondition> preconditions, EventArgs args)
    {
      foreach (var precondition in preconditions)
      {
        Log.This.Info("Evaluating precondition: {0}", precondition.Name.ActiveForm);
        if (precondition.Evaluate(this, args))
        {
          Log.This.Info("Precondition met: {0}", precondition.Name.ActiveForm);
        }
        else
        {
          Log.This.Error("Precondition NOT met: {0}", precondition.Name.ActiveForm);
          if (string.IsNullOrEmpty(precondition.ErrorMessage) == false)
            Log.This.Error(precondition.ErrorMessage);
          if (PreconditionNotMet != null)
            PreconditionNotMet(Pipeline, new GenericEventArgs<string>(precondition.ErrorMessage));
          return false;
        }
      }

      return true;
    }

    private void InnerExecuteAllSteps(object sender, EventArgs args)
    {
      var totalCount = Pipeline.Steps.Count();
      foreach (var step in Pipeline.Steps)
      {
        var infoArgs = new PipelineStepInfoEventArgs(step.Order, totalCount, step.Name.ActiveForm);
        if (StepExecuting != null)
          StepExecuting(step, infoArgs);

        if (PreconditionsAreMet(step.Preconditions, args))
        {
          Log.This.Info(step.Name.ActiveForm);
          var elapsed = Profiler.This(step.Invoke, sender, args);
          Log.This.Profile(step.Name.ActiveForm, elapsed);
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
