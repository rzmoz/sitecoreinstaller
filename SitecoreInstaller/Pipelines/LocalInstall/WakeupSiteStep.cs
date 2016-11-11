using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class WakeUpSiteStep : PipelineStep<InstallLocalArgs>
    {
        private readonly WebsiteService _websiteService;

        public WakeUpSiteStep(WebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        protected override async Task RunImpAsync(InstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            await _websiteService.WakeUpSiteAsync(args.Info.Url).ConfigureAwait(false);
        }
    }
}
