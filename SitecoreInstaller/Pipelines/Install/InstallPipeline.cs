using Autofac;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallPipeline : DeploymentDirPipeline<InstallArgs>
    {
        public InstallPipeline(IContainer container, DeploymentsService deploymentsService, WebsiteService websiteService) : base(container, deploymentsService)
        {
            AddStep<CopyDeploymentFilesStep>();

            AddStep<InitWebsiteStep>();

            AddStep<InitInstallConnectionStringsStep>();
            AddStep<AttachSqlhDatabasesStep>();
            AddStep<AddSiteToHostFileStep>();
            AddStep<CreateWebsiteAndAppPoolStep>();
            AddStep(nameof(WakeupSiteStep), (args, ct) => new WakeupSiteStep(websiteService).RunAsync(args, ct));
        }
    }
}
