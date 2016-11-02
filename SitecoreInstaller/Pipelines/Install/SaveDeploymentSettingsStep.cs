using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class SaveDeploymentSettingsStep : PipelineStep<LocalInstallArgs>
    {
        private readonly DeploymentsService _deploymentsService;

        public SaveDeploymentSettingsStep(DeploymentsService deploymentsService)
        {
            if (deploymentsService == null) throw new ArgumentNullException(nameof(deploymentsService));
            _deploymentsService = deploymentsService;
        }

        protected override Task RunImpAsync(LocalInstallArgs args, CancellationToken ct)
        {
            _deploymentsService.SaveDeploymentInfo(args.Info, args.DeploymentDir);
            return Task.CompletedTask;
        }
    }
}
