using Autofac;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallPipeline : DeploymentDirPipeline<InstallArgs>
    {
        public InstallPipeline(IContainer container, DeploymentsService deploymentsService) : base(container, deploymentsService)
        {
            AddStep<CopyDeploymentFilesStep>();
            AddStep<InitInstallConnectionStringsStep>();
            AddStep<InitWebsiteStep>();
            AddStep<AttachSqlhDatabasesStep>();
        }
    }
}
