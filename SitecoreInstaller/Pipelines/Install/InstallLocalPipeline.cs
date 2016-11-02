using Autofac;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallLocalPipeline : DeploymentDirPipeline<LocalInstallArgs>
    {
        public InstallLocalPipeline(IContainer container, DeploymentsService deploymentsService, WebsiteService websiteService, AdvancedSettings advancedSettings) : base(container, deploymentsService, advancedSettings)
        {
            AddStep<SaveDeploymentSettingsStep>();
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
