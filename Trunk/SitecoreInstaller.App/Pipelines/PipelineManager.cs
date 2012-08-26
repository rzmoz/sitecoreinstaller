using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class PipelineManager
    {
        public void Run<T>() where T : class,IPipeline, new()
        {
            Services.PipelineWorker.RunPipeline(Get<T>());
        }

        public PipelineRunner<T> Get<T>() where T : class,IPipeline, new()
        {
            return new PipelineRunner<T>(new T());
        }
    }
}
