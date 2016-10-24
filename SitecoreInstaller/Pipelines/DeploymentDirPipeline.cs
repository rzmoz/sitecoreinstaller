using Autofac;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines
{
    public class DeploymentDirPipeline<T> : Pipeline<T> where T : SitecoreInstallerEventArgs, new()
    {
        public DeploymentDirPipeline(IContainer container, DeploymentsService deploymentsService) : base(container)
        {
            AddStep(nameof(InitDeploymentDirStep), (args, ct) => new InitDeploymentDirStep(deploymentsService).RunAsync(args, ct));
        }
    }
}
