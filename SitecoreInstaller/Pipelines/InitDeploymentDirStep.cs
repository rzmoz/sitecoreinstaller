using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines
{
    public class InitDeploymentDirStep<T> : PipelineStep<T> where T : LocalArgs, new()
    {
        private readonly LocalDeploymentsService _localDeploymentsService;
        private readonly AdvancedSettings _advancedSettings;

        public InitDeploymentDirStep(LocalDeploymentsService localDeploymentsService, AdvancedSettings advancedSettings)
        {
            _localDeploymentsService = localDeploymentsService;
            _advancedSettings = advancedSettings;
        }

        protected override Task RunImpAsync(T args, TaskIssueList issues, CancellationToken ct)
        {
            //must be initializaed as the first thing!
            args.DeploymentDir = _localDeploymentsService.GetDeploymentDir(args.Info.Name, initialize: true);
            //ensure url is set
            args.Info.Url = _advancedSettings.GetDeploymentUrl(args.Info.Name);

            if (args.DeploymentDir.DeploymentInfo.Exists())
                args.Info = args.DeploymentDir.LoadDeploymentInfo();

            args.Info.Task.Name = args.CurrentTaskName;
            args.Info.Task.Status = DeploymentStatus.InProgress;

            args.DeploymentDir.SaveDeploymentInfo(args.Info);
            return Task.CompletedTask;
        }
    }
}
