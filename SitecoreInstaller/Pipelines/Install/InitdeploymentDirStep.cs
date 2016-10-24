using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitDeploymentDirStep : PipelineStep<InstallEventArgs>
    {
        private readonly DeploymentsService _deploymentsService;

        public InitDeploymentDirStep(DeploymentsService deploymentsService)
        {
            _deploymentsService = deploymentsService;
        }

        protected override Task InnerRunAsync(InstallEventArgs args, CancellationToken ct)
        {
            _deploymentsService.InitDeploymentDir(args.Name);
            args.DeploymentDir = _deploymentsService.DeploymentDir(args.Name);
            return Task.CompletedTask;
        }
    }
}
