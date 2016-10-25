using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines
{
    public class WakeupSiteStep : PipelineStep<SitecoreInstallerEventArgs>
    {
        private readonly WebsiteService _websiteService;

        public WakeupSiteStep(WebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        protected override Task RunImpAsync(SitecoreInstallerEventArgs args, CancellationToken ct)
        {
            _websiteService.PingSite(args.Name);
            return Task.CompletedTask;
        }
    }
}
