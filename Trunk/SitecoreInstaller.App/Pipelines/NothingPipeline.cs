using System;
using System.Threading;

using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Steps.Nothing;

  public class NothingPipeline : Pipeline
  {
    public NothingPipeline()
    {
      //Init steps
      AddStep<DoNothing>();
      AddStep<DoNothingForAWhile>();
    }
  }
}
