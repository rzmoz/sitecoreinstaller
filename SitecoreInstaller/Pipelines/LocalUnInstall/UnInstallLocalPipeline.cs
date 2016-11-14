using System;
using Autofac;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{
    public class UnInstallLocalPipeline : LocalPipeline<UnInstallLocalArgs>
    {
        public UnInstallLocalPipeline(Func<IContainer> getContainer) : base(getContainer)
        {/*
            AddStep<DeleteWebsiteAndAppPoolStep>();
            AddStep<RemoveSiteFromHostFileStep>();
            AddStep<InitUnInstallConnectionStringsStep>();
            AddStep<DetachSqlDatabasesStep>();
            AddStep<DropMongoDatabasesStep>();
            AddStep<DeleteDeploymentDirStep>();*/
        }
    }
}
