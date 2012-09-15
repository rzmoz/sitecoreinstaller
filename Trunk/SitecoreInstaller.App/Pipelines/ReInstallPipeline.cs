using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Steps.Install;
    using SitecoreInstaller.Domain.Pipelines;

    public class ReinstallPipeline : Pipeline
    {
        public ReinstallPipeline()
        {
            var installPipeline = new InstallPipeline();
            var uninstallPipeline = new UninstallPipeline();

            AddPreconditions(installPipeline.Preconditions);
            AddStep<UpdateAppSettings>();
            AddSteps(uninstallPipeline.Steps);
            AddSteps(installPipeline.Steps);
        }
    }
}
