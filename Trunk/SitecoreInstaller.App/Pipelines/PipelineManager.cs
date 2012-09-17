using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class PipelineManager
    {
        public void Run<T>(bool killDialogs = false) where T : class,IPipeline, new()
        {
            var runner = Get<T>();
            runner.Pipeline.IsInUiMode = !killDialogs;
            Services.PipelineWorker.RunPipeline(runner);
        }

        public PipelineRunner<T> Get<T>() where T : class,IPipeline, new()
        {
            return new PipelineRunner<T>(new T());
        }
    }
}
