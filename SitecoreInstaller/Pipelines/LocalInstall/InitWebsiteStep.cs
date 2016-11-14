using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.LocalInstall
{/*
    public class InitWebsiteStep : PipelineStep<InstallLocalArgs>
    {
        private readonly WebsiteService _websiteService;

        public InitWebsiteStep(WebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        protected override Task RunImpAsync(InstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            Parallel.Invoke(
                () => _websiteService.InitDataFolderConfig(args.DeploymentDir),
                () => _websiteService.InitRuntimeServices(args.DeploymentDir));
            return Task.CompletedTask;
        }
    }*/
}
