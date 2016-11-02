using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines
{
    public class InitDeploymentDirStep : PipelineStep<LocalInstallerEventArgs>
    {
        private readonly DeploymentsService _deploymentsService;

        public InitDeploymentDirStep(DeploymentsService deploymentsService)
        {
            _deploymentsService = deploymentsService;
        }
        
        protected override Task RunImpAsync(LocalInstallerEventArgs args, CancellationToken ct)
        {
            args.DeploymentDir = _deploymentsService.InitDeploymentDir(args.Name);
            return Task.CompletedTask;
        }
    }
}
