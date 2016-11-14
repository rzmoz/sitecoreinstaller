using System;
using Autofac;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class InstallLocalPipeline : LocalPipeline<InstallLocalArgs>
    {
        public InstallLocalPipeline(Func<IContainer> getContainer) : base(getContainer)
        {/*
            AddStep<CopyDeploymentFilesStep>();
            AddStep<InitWebsiteStep>();
            AddStep<InitInstallConnectionStringsStep>();
            AddStep<AttachSqlhDatabasesStep>();
            AddStep<AddSiteToHostFileStep>();
            AddStep<CreateWebsiteAndAppPoolStep>();
            AddStep<WakeUpSiteStep>();
            AddStep<InstallLocalSuccessStep<InstallLocalArgs>>();*/
        }
    }
}
