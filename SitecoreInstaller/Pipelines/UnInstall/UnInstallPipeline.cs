using Autofac;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallPipeline : DeploymentDirPipeline<UnInstallArgs>
    {
        public UnInstallPipeline(IContainer container, DeploymentsService deploymentsService) : base(container, deploymentsService)
        {
            AddStep<InitUnInstallConnectionStringsStep>();
            AddBlock("Cleanup Databases")
                .AddStep<DetachSqlDatabasesStep>()
                .AddStep<DropMongoDatabasesStep>();
            AddStep<DeleteDeploymentDirStep>();
        }
    }
}
