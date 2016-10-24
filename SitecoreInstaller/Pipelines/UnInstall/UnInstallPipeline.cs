using Autofac;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallPipeline : DeploymentDirPipeline<UnInstallArgs>
    {
        public UnInstallPipeline(IContainer container, DeploymentsService deploymentsService) : base(container, deploymentsService)
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
