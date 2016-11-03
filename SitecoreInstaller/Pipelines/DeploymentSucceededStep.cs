using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines
{
    public class DeploymentSucceededStep<T> : PipelineStep<T> where T : LocalArgs, new()
    {
        private readonly LocalDeploymentsService _localDeploymentsService;

        public DeploymentSucceededStep(LocalDeploymentsService localDeploymentsService)
        {
            _localDeploymentsService = localDeploymentsService;
        }

        protected override Task RunImpAsync(T args, CancellationToken ct)
        {
            args.Info.Status = DeploymentStatus.Success;
            _localDeploymentsService.SaveDeploymentInfo(args.Info, args.DeploymentDir);

            return Task.CompletedTask;
        }
    }
}
