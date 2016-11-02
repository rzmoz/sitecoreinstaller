using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines
{
    public class WakeupSiteStep : PipelineStep<LocalInstallerEventArgs>
    {
        private readonly WebsiteService _websiteService;

        public WakeupSiteStep(WebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        protected override Task RunImpAsync(LocalInstallerEventArgs args, CancellationToken ct)
        {
            _websiteService.PingSiteNoWait(args.Info.Url);
            return Task.CompletedTask;
        }
    }
}
