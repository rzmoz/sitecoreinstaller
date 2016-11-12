using Autofac;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines
{
    public class LocalPipeline<T> : Pipeline<T> where T : LocalArgs, new()
    {
        public LocalPipeline(IContainer container) : base(container, Invoke.Sequential)
        {
            AddStep<InitDeploymentDirStep<T>>();
        }
    }
}
