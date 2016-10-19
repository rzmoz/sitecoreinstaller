using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitdeploymentDirStep : PipelineStep<EventArgs<DeploymentSettings>>
    {
        private readonly DeploymentsService _deploymentsService;

        public InitdeploymentDirStep(DeploymentsService deploymentsService) : base(null)
        {
            _deploymentsService = deploymentsService;
        }

        protected override async Task InnerRunAsync(EventArgs<DeploymentSettings> args, CancellationToken ct)
        {
            _deploymentsService.InitDeploymentDir(args.Value.Name);
        }
    }
}
