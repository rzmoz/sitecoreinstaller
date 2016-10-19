using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitProjectDirStep : PipelineStep<EventArgs<ProjectSettings>>
    {
        private readonly WebsiteService _websiteService;

        public InitProjectDirStep(WebsiteService websiteService) : base(null)
        {
            _websiteService = websiteService;
        }

        protected override async Task InnerRunAsync(EventArgs<ProjectSettings> args, CancellationToken ct)
        {
            _websiteService.InitProjectDir(args.Value.Name);
        }
    }
}
