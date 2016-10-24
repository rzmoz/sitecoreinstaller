using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines
{
    public class InitDeploymentDirStep : PipelineStep<SitecoreInstallerEventArgs>
    {
        private readonly DeploymentsService _deploymentsService;

        public InitDeploymentDirStep(DeploymentsService deploymentsService)
        {
            _deploymentsService = deploymentsService;
        }
        
        protected override Task RunImpAsync(SitecoreInstallerEventArgs args, CancellationToken ct)
        {
            args.DeploymentDir = _deploymentsService.InitDeploymentDir(args.Name);
            return Task.CompletedTask;
        }
    }
}
