using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.Domain.Pipelines;

    public class ReInstallPipeline : Pipeline
    {
        public ReInstallPipeline()
        {
            var installPipeline = new InstallPipeline();
            var uninstallPipeline = new UninstallPipeline();

            AddPreconditions(installPipeline.Preconditions);

        }
    }
}
