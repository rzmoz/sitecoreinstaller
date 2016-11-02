using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines
{
    public class InitDeploymentDirStep : PipelineStep<LocalInstallerEventArgs>
    {
        private readonly DeploymentsService _deploymentsService;
        private readonly AdvancedSettings _advancedSettings;

        public InitDeploymentDirStep(DeploymentsService deploymentsService, AdvancedSettings advancedSettings)
        {
            _deploymentsService = deploymentsService;
            _advancedSettings = advancedSettings;
        }

        protected override Task RunImpAsync(LocalInstallerEventArgs args, CancellationToken ct)
        {
            //must be initializaed as the first thing!
            args.DeploymentDir = _deploymentsService.GetDeploymentDir(args.Info.Name,initialize: true);

            //ensure url is set
            args.Info.Url = _advancedSettings.GetDeploymentUrl(args.Info.Name);

            var loadedInfo = _deploymentsService.GetDeploymentInfo(args.DeploymentDir);
            if (loadedInfo != null)
                args.Info = loadedInfo;

            return Task.CompletedTask;
        }
    }
}
