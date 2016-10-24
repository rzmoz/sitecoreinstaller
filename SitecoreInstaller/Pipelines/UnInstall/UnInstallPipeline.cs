using Autofac;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallPipeline : Pipeline<UnInstallArgs>
    {
        public UnInstallPipeline(IContainer container, DeploymentsService deploymentsService) : base(container)
        {
            AddStep((args, ct) => new InitDeploymentDirStep(deploymentsService).RunAsync(args, ct));
            AddStep<InitUnInstallConnectionStringsStep>();
            AddStep<DetachSqlDatabasesStep>();
            AddStep<DeleteDeploymentDirStep>();
        }
    }
}
