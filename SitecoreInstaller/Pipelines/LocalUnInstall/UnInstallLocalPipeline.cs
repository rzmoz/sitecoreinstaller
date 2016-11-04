using Autofac;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{
    public class UnInstallLocalPipeline : LocalPipeline<UnInstallLocalArgs>
    {
        public UnInstallLocalPipeline(IContainer container) : base(container)
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
