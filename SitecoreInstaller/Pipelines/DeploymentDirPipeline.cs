using Autofac;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines
{
    public class DeploymentDirPipeline<T> : Pipeline<T> where T : LocalArgs, new()
    {
        public DeploymentDirPipeline(IContainer container) : base(container)
        {
            AddStep<InitDeploymentDirStep<T>>();
        }
    }
}
