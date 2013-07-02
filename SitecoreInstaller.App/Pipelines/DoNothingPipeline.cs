using System;
using System.Threading;

using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Steps.Nothing;

  public class DoNothingPipeline : Pipeline
  {
    public DoNothingPipeline()
    {
      //Init steps
      AddStep<DoNothing>();
      AddStep<DoNothingForAWhile>();
    }
  }
}
