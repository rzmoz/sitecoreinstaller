using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class DeleteWebsiteAndAppPoolStep : PipelineStep<UnInstallArgs>
    {
        private readonly IisManagementService _iisManagementService;

        public DeleteWebsiteAndAppPoolStep(IisManagementService iisManagementService)
        {
            _iisManagementService = iisManagementService;
        }

        protected override Task RunImpAsync(UnInstallArgs args, CancellationToken ct)
        {
            _iisManagementService.StopApplication(args.Name);
            _iisManagementService.DeleteApplication(args.Name);
            return Task.CompletedTask;
        }
    }
}
