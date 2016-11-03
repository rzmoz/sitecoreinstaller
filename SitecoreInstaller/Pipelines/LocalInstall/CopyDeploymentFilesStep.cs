using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class CopyDeploymentFilesStep : PipelineStep<InstallLocalArgs>
    {
        private readonly LocalDeploymentsService _localDeploymentsService;
        private readonly LocalBuildLibrary _buildLibrary;
        private readonly WebsiteService _websiteService;

        public CopyDeploymentFilesStep(LocalDeploymentsService localDeploymentsService, LocalBuildLibrary buildLibrary, WebsiteService websiteService)
        {
            _localDeploymentsService = localDeploymentsService;
            _buildLibrary = buildLibrary;
            _websiteService = websiteService;
        }

        protected override Task RunImpAsync(InstallLocalArgs args, CancellationToken ct)
        {
            var sitecore = _buildLibrary.GetSitecore(args.Info.Sitecore);
            _localDeploymentsService.CopySitecore(sitecore, args.DeploymentDir);
            var license = _buildLibrary.GetLicense(args.Info.License);
            _localDeploymentsService.CopyLicenseFile(license, args.DeploymentDir);
            var modules = (from module in args.Info.Modules select _buildLibrary.GetModule(module)).ToList();
            _localDeploymentsService.CopyModules(modules, args.DeploymentDir);
            _websiteService.FixReportingDatabaseFileNames(args.DeploymentDir);

            return Task.CompletedTask;
        }
    }
}
