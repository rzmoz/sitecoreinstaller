using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class DeleteDeploymentDirStep : PipelineStep<UnInstallArgs>
    {
        private readonly DeploymentsService _deploymentsService;

        public DeleteDeploymentDirStep(DeploymentsService deploymentsService)
        {
            _deploymentsService = deploymentsService;
        }

        protected override async Task InnerRunAsync(UnInstallArgs args, CancellationToken ct)
        {
            args.WasDeleted = _deploymentsService.DeleteDeploymentDir(args.Name);
        }
    }
}
