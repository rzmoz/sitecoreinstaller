using Autofac;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallLocalPipeline : DeploymentDirPipeline<UnInstallArgs>
    {
        public UnInstallLocalPipeline(IContainer container, DeploymentsService deploymentsService, AdvancedSettings advancedSettings) : base(container, deploymentsService, advancedSettings)
        {
            AddStep<DeleteWebsiteAndAppPoolStep>();
            AddStep<RemoveSiteFromHostFileStep>();
            AddStep<InitUnInstallConnectionStringsStep>();
            AddStep<DetachSqlDatabasesStep>();
            AddStep<DropMongoDatabasesStep>();
            AddStep<DeleteDeploymentDirStep>();
        }
    }
}
