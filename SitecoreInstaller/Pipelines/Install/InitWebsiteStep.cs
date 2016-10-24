using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitWebsiteStep : PipelineStep<InstallArgs>
    {
        private readonly WebsiteService _websiteService;

        public InitWebsiteStep(WebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        protected override Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            Parallel.Invoke(
                () => _websiteService.InitDataFolderConfig(args.DeploymentDir),
                () => _websiteService.InitRuntimeServices(args.DeploymentDir),
                () => _websiteService.FixReportingDatabaseFileNames(args.DeploymentDir));
            return Task.CompletedTask;
        }
    }
}
