using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class CopyDeploymentFilesStep : PipelineStep<InstallEventArgs>
    {
        private readonly DeploymentsService _deploymentsService;
        private readonly LocalBuildLibrary _buildLibrary;

        public CopyDeploymentFilesStep(DeploymentsService deploymentsService, LocalBuildLibrary buildLibrary)
        {
            _deploymentsService = deploymentsService;
            _buildLibrary = buildLibrary;
        }

        protected override Task InnerRunAsync(InstallEventArgs args, CancellationToken ct)
        {
            var sitecore = _buildLibrary.GetSitecore(args.Sitecore);
            _deploymentsService.CopySitecore(sitecore, args.Name);
            var license = _buildLibrary.GetLicense(args.License);
            _deploymentsService.CopyLicenseFile(license, args.Name);
            var modules = (from module in args.Modules select _buildLibrary.GetModule(module)).ToList();
            _deploymentsService.CopyModules(modules, args.Name);
            _deploymentsService.CopyRuntimeServices(args.Name);
            return Task.CompletedTask;
        }
    }
}
