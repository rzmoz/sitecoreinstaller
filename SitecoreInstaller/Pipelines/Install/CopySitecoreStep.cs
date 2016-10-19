using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class CopySitecoreStep : PipelineStep<EventArgs<DeploymentSettings>>
    {
        private readonly DeploymentsService _deploymentsService;
        private readonly LocalBuildLibrary _buildLibrary;

        public CopySitecoreStep(DeploymentsService deploymentsService, LocalBuildLibrary buildLibrary)
        {
            _deploymentsService = deploymentsService;
            _buildLibrary = buildLibrary;
        }

        protected override async Task InnerRunAsync(EventArgs<DeploymentSettings> args, CancellationToken ct)
        {
            var sitecore = _buildLibrary.GetSitecore(args.Value.Sitecore);
            _deploymentsService.CopySitecore(sitecore, args.Value.Name);
        }
    }
}
