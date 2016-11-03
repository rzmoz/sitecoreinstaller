using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{
    public class DeleteDeploymentDirStep : PipelineStep<UnInstallLocalArgs>
    {
        private readonly LocalDeploymentsService _localDeploymentsService;

        public DeleteDeploymentDirStep(LocalDeploymentsService localDeploymentsService)
        {
            _localDeploymentsService = localDeploymentsService;
        }

        protected override Task RunImpAsync(UnInstallLocalArgs args, CancellationToken ct)
        {
            args.WasDeleted = _localDeploymentsService.DeleteDeploymentDir(args.DeploymentDir);
            return Task.CompletedTask;
        }
    }
}
