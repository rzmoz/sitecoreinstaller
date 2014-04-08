
using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps.Install;
using SitecoreInstaller.App.Pipelines.Steps.Nothing;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class DoNothingPipeline : Pipeline<DoNothingEventArgs>
    {
        public DoNothingPipeline()
        {
            //Init preconditions
            AddPrecondition<CheckNothing>();

            //Init steps
            AddStep<TransformConfigFiles>();
            //AddStep<DoNothingStep1>();
            //AddStep<DoNothingStep2>();
        }
    }
}
