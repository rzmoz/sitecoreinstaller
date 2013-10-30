using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using System;
  using System.Collections.Generic;

  public class PipelineService
  {
    public void Run<T, TK>(ProjectSettings projectSettings, params Action<TK>[] preProcessors)
      where TK : PipelineEventArgs
      where T : class,IPipeline, new()
    {
      if (projectSettings == null) { throw new ArgumentNullException("projectSettings"); }

      var runner = Get<T, TK>(preProcessors);

      if (runner.Pipeline.Args is PipelineApplicationEventArgs == false)
        throw new TypeLoadException("pipeline args is not " + typeof(PipelineApplicationEventArgs));
      (runner.Pipeline.Args as PipelineApplicationEventArgs).ProjectSettings = projectSettings;

      Services.PipelineWorker.RunPipeline(runner);
    }

    public PipelineRunner<T, TK> Get<T, TK>(IEnumerable<Action<TK>> preProcessors)
      where T : class,IPipeline, new()
      where TK : PipelineEventArgs
    {
      return new PipelineRunner<T, TK>(new T(), preProcessors);
    }
  }
}
