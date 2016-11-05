using Autofac;
using SitecoreInstaller.Pipelines.LocalInstall;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class InstallLocalPipeline : LocalPipeline<InstallLocalArgs>
    {
        public InstallLocalPipeline(IContainer container) : base(container)
        {
            AddStep<CopyDeploymentFilesStep>();
            AddStep<InitWebsiteStep>();
            AddStep<InitInstallConnectionStringsStep>();
            AddStep<AttachSqlhDatabasesStep>();
            AddStep<AddSiteToHostFileStep>();
            AddStep<CreateWebsiteAndAppPoolStep>();
            AddStep<WakeUpSiteStep>();
            AddStep<InstallLocalSuccessStep<InstallLocalArgs>>();
        }
    }
}
