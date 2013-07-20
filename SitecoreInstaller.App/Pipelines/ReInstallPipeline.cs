using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Preconditions;
  using SitecoreInstaller.App.Pipelines.Steps.Install;
  using SitecoreInstaller.Domain.Pipelines;

  public class ReinstallPipeline : Pipeline<PipelineEventArgs>
  {
    public ReinstallPipeline()
    {
      var installPipeline = new InstallPipeline();
      var uninstallPipeline = new UninstallPipeline();

      //Init preconditions
      AddPreconditions(installPipeline.Preconditions);
      RemovePrecondition<CheckProjectDoesNotExist>();
      RemovePrecondition<CheckBinding>();
      AddPrecondition<CheckProjectExists>();

      //Init steps
      AddStep<SaveProjectSettings>();
      AddSteps(uninstallPipeline.Steps);
      AddSteps(installPipeline.Steps);
    }
  }
}
