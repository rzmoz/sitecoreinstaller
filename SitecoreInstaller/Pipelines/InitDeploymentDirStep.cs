using System.Threading;
using System.Threading.Tasks;
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

        protected override Task RunImpAsync(T args, CancellationToken ct)
        {
            //must be initializaed as the first thing!
            args.DeploymentDir = _localDeploymentsService.GetDeploymentDir(args.Info.Name, initialize: true);
            //ensure url is set
            args.Info.Url = _advancedSettings.GetDeploymentUrl(args.Info.Name);

            var loadedInfo = args.DeploymentDir.GetDeploymentInfo();
            if (loadedInfo != null)
                args.Info = loadedInfo;

            args.Info.Done = false;
            _localDeploymentsService.SaveDeploymentInfo(args.Info, args.DeploymentDir);

            return Task.CompletedTask;
        }
    }
}
