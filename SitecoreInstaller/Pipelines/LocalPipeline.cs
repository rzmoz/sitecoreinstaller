using System;
using Autofac;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines
{
    public class LocalPipeline<T> : Pipeline<T> where T : LocalArgs, new()
    {
        public LocalPipeline(Func<IContainer> getContainer) : base(getContainer)
        {
            AddStep<InitDeploymentDirStep<T>>();
        }
    }
}
