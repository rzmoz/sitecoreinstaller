using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using System;

  public class PipelineService
  {
    public void Run<T>(ProjectSettings projectSettings) where T : class,IPipeline, new()
    {
      if (projectSettings == null) { throw new ArgumentNullException("projectSettings"); }

      var runner = Get<T>();
      var pipelineEventArgs = runner.Pipeline.Args as PipelineEventArgs;
      if (pipelineEventArgs == null)
        throw new TypeLoadException("pipeline args is not " + typeof(PipelineEventArgs));
      pipelineEventArgs.ProjectSettings = projectSettings;

      Services.PipelineWorker.RunPipeline(runner);
    }

    public PipelineRunner<T> Get<T>() where T : class,IPipeline, new()
    {
      return new PipelineRunner<T>(new T());
    }
  }
}
