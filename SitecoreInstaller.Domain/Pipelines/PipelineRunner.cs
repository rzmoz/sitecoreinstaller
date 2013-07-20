﻿using System;
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
  public class PipelineRunner<T> : IPipelineRunner where T : class,IPipeline
  {
    public event EventHandler<PipelineInfoEventArgs> AllStepsExecuting;
    public event EventHandler<PipelineInfoEventArgs> AllStepsExecuted;

    public event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
    public event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

    public event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

    public T Pipeline { get; private set; }

    public PipelineRunner(T pipeline, string executeAllText = "")
    {
      if (pipeline == null) throw new ArgumentNullException("pipeline");

      Log.This.Clear();
      ExecuteAllText = executeAllText;
      Pipeline = pipeline;
    }

    public string ExecuteAllText { get; private set; }

    public void ExecuateAllSteps(object sender, EventArgs e)
    {
      if (PreconditionsAreMet(Pipeline.Preconditions, Pipeline.Name.ToString(), Pipeline.Args))
      {
        if (AllStepsExecuting != null)
          AllStepsExecuting(sender, new PipelineInfoEventArgs(Pipeline));

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

    private bool PreconditionsAreMet(IEnumerable<IPrecondition> preconditions, string taskName, EventArgs args)
    {
      Log.This.Info("Evaluating preconditions for {0}", taskName);

      foreach (var precondition in preconditions)
      {
        if (precondition.Evaluate(this, args))
        {
          Log.This.Info("Precondition met: {0}", precondition.Name.ActiveForm);
        }
        else
        {
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

        if (PreconditionsAreMet(step.Preconditions, step.Name.ActiveForm, args))
        {
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
