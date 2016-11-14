using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{/*
    public class DeleteWebsiteAndAppPoolStep : PipelineStep<UnInstallLocalArgs>
    {
        private readonly IisManagementService _iisManagementService;

        public DeleteWebsiteAndAppPoolStep(IisManagementService iisManagementService)
        {
            _iisManagementService = iisManagementService;
        }

        protected override Task RunImpAsync(UnInstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            _iisManagementService.StopApplication(args.Info.Name);
            _iisManagementService.DeleteApplication(args.Info.Name);
            return Task.CompletedTask;
        }
    }*/
}
