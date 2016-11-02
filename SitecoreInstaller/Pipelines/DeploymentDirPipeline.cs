using Autofac;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines
{
    public class DeploymentDirPipeline<T> : Pipeline<T> where T : LocalInstallerEventArgs, new()
    {
        public DeploymentDirPipeline(IContainer container, DeploymentsService deploymentsService, AdvancedSettings advancedSettings) : base(container)
        {
            AddStep(nameof(InitDeploymentDirStep), (args, ct) => new InitDeploymentDirStep(deploymentsService, advancedSettings).RunAsync(args, ct));
        }
    }
}
