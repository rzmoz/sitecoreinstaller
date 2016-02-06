using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps.Publishing;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class PublishPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public PublishPipeline()
        {
            //Init preconditions
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckProjectExists>();

            //Init steps
            AddStep<PublishSite>();
        }
    }
}
