using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.Install
{
    public class CopyDeploymentFilesStep : PipelineStep<LocalInstallArgs>
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

        protected override Task RunImpAsync(LocalInstallArgs args, CancellationToken ct)
        {
            var sitecore = _buildLibrary.GetSitecore(args.Info.Sitecore);
            _deploymentsService.CopySitecore(sitecore, args.DeploymentDir);
            var license = _buildLibrary.GetLicense(args.Info.License);
            _deploymentsService.CopyLicenseFile(license, args.DeploymentDir);
            var modules = (from module in args.Info.Modules select _buildLibrary.GetModule(module)).ToList();
            _deploymentsService.CopyModules(modules, args.DeploymentDir);
            _websiteService.FixReportingDatabaseFileNames(args.DeploymentDir);

            return Task.CompletedTask;
        }
    }
}
