using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using System;
  using System.Collections.Generic;

  public class PipelineService
  {
    public void Run<T, TK>(ProjectSettings projectSettings, params Action<TK>[] preProcessors)
      where TK : EventArgs
      where T : class,IPipeline, new()
    {
      if (projectSettings == null) { throw new ArgumentNullException("projectSettings"); }

      var runner = Get<T, TK>(preProcessors);

      if (runner.Pipeline.Args is PipelineEventArgs == false)
        throw new TypeLoadException("pipeline args is not " + typeof(PipelineEventArgs));
      (runner.Pipeline.Args as PipelineEventArgs).ProjectSettings = projectSettings;

      Services.PipelineWorker.RunPipeline(runner);
    }

    public PipelineRunner<T, TK> Get<T, TK>(IEnumerable<Action<TK>> preProcessors)
      where T : class,IPipeline, new()
      where TK : EventArgs
    {
      return new PipelineRunner<T, TK>(new T(), preProcessors);
    }
  }
}
