using Autofac;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallPipeline : Pipeline<InstallArgs>
    {
        public InstallPipeline(IContainer container, DeploymentsService deploymentsService) : base(container)
        {
            AddStep((args, ct) => new InitDeploymentDirStep(deploymentsService).RunAsync(args, ct));
            AddStep<CopyDeploymentFilesStep>();
            AddStep<InitInstallConnectionStringsStep>();
            AddStep<InitWebsiteStep>();
            AddStep<AttachSqlhDatabasesStep>();
            
        }
    }
}
