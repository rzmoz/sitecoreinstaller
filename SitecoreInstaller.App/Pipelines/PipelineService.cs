using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using System;

  public class PipelineService
  {
    public void Run<T>(ProjectSettings projectSettings, Dialogs dialogs = Dialogs.On) where T : class,IPipeline, new()
    {
      if (projectSettings == null) { throw new ArgumentNullException("projectSettings"); }

      var runner = Get<T>();
      runner.Pipeline.Dialogs = dialogs;
      runner.Pipeline.Args = new StepEventArgs { ProjectSettings = projectSettings };
      Services.PipelineWorker.RunPipeline(runner);
    }

    public PipelineRunner<T> Get<T>() where T : class,IPipeline, new()
    {
      return new PipelineRunner<T>(new T());
    }
  }
}
