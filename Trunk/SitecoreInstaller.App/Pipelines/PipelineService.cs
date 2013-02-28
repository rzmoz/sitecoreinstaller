using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  public class PipelineService
  {
    public void Run<T>(Dialogs dialogs = Dialogs.On) where T : class,IPipeline, new()
    {
      var runner = Get<T>();
      runner.Pipeline.Dialogs = dialogs;
      Services.PipelineWorker.RunPipeline(runner);
    }

    public PipelineRunner<T> Get<T>() where T : class,IPipeline, new()
    {
      return new PipelineRunner<T>(new T());
    }
  }
}
