using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitDeploymentDirStep : PipelineStep<EventArgs<DeploymentSettings>>
    {
        private readonly DeploymentsService _deploymentsService;

        public InitDeploymentDirStep(DeploymentsService deploymentsService)
        {
            _deploymentsService = deploymentsService;
        }

        protected override Task InnerRunAsync(EventArgs<DeploymentSettings> args, CancellationToken ct)
        {
            _deploymentsService.InitDeploymentDir(args.Value.Name);
            return Task.CompletedTask;
        }
    }
}
