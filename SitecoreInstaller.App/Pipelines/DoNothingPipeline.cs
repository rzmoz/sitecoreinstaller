using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Preconditions;
  using SitecoreInstaller.App.Pipelines.Steps;
  using SitecoreInstaller.App.Pipelines.Steps.Nothing;

  public class DoNothingPipeline : Pipeline<DoNothingEventArgs>
  {
    public DoNothingPipeline()
    {
      //Init preconditions
      AddPrecondition<CheckNothing>();

      //Init steps
      AddStep<DoNothing>();
      AddStep<DoNothingForAWhile>();
      AddStep<WarmUpSite>();
    }
  }
}
