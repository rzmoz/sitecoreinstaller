using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class DeleteProjectDirStep : PipelineStep<UnInstallArgs>
    {
        private readonly WebsiteService _websiteService;

        public DeleteProjectDirStep(WebsiteService websiteService) : base(null)
        {
            _websiteService = websiteService;
        }

        protected override async Task InnerRunAsync(UnInstallArgs args, CancellationToken ct)
        {
            args.WasDeleted = _websiteService.DeleteProjectDir(args.Name);
        }
    }
}
