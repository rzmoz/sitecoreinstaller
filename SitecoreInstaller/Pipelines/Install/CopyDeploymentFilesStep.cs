using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.Install
{
    public class CopyDeploymentFilesStep : PipelineStep<InstallArgs>
    {
        private readonly DeploymentsService _deploymentsService;
        private readonly LocalBuildLibrary _buildLibrary;
        private readonly WebsiteService _websiteService;

        public CopyDeploymentFilesStep(DeploymentsService deploymentsService, LocalBuildLibrary buildLibrary, WebsiteService websiteService)
        {
            _deploymentsService = deploymentsService;
            _buildLibrary = buildLibrary;
            _websiteService = websiteService;
        }

        protected override Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            var sitecore = _buildLibrary.GetSitecore(args.Sitecore);
            _deploymentsService.CopySitecore(sitecore, args.Name);
            var license = _buildLibrary.GetLicense(args.License);
            _deploymentsService.CopyLicenseFile(license, args.Name);
            var modules = (from module in args.Modules select _buildLibrary.GetModule(module)).ToList();
            _deploymentsService.CopyModules(modules, args.Name);
            _websiteService.FixReportingDatabaseFileNames(args.DeploymentDir);
            return Task.CompletedTask;
        }
    }
}
