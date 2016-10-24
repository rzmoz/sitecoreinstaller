using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class RemoveSiteFromHostFileStep : PipelineStep<UnInstallArgs>
    {
        private readonly HostFile _hostFile;

        public RemoveSiteFromHostFileStep(HostFile hostFile)
        {
            _hostFile = hostFile;
        }

        protected override Task RunImpAsync(UnInstallArgs args, CancellationToken ct)
        {
            _hostFile.RemoveHostName(args.DeploymentUrl);
            
            return Task.CompletedTask;
        }
    }
}
