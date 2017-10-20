using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class CopyDeploymentFilesStep : PipelineStep<InstallLocalArgs>
    {
        private readonly DiskBuildLibrary _buildLibrary;
        private readonly WebsiteService _websiteService;

        public CopyDeploymentFilesStep(DiskBuildLibrary buildLibrary, WebsiteService websiteService)
        {
            _buildLibrary = buildLibrary;
            _websiteService = websiteService;
        }

        protected override Task RunImpAsync(InstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            var sitecore = _buildLibrary.GetSitecore(args.Info.Sitecore);
            args.DeploymentDir.CopySitecore(sitecore);
            var license = _buildLibrary.GetLicense(args.Info.License);
            args.DeploymentDir.CopyLicenseFile(license);
            var modules = (from module in args.Info.Modules select _buildLibrary.GetModule(module)).ToList();
            args.DeploymentDir.CopyModules(modules);
            _websiteService.FixReportingDatabaseFileNames(args.DeploymentDir);

            return Task.CompletedTask;
        }
    }
}
