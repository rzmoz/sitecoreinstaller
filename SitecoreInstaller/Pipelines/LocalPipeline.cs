using Autofac;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines
{
    public class LocalPipeline<T> : Pipeline<T> where T : LocalArgs, new()
    {
        public LocalPipeline(IContainer container) : base(container)
        {
            AddStep<InitDeploymentDirStep<T>>();
        }
    }
}
