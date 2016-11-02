using Autofac;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallLocalPipeline : DeploymentDirPipeline<UnInstallArgs>
    {
        public UnInstallLocalPipeline(IContainer container, DeploymentsService deploymentsService) : base(container, deploymentsService)
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
