using System;
using Autofac;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines
{
    public class LocalPipeline<T> : Pipeline<T>, IPreflightCheck where T : LocalArgs, new()
    {
        public LocalPipeline(Func<IContainer> getContainer) : base(getContainer)
        {
            AddStep<InitDeploymentDirStep<T>>();
        }

        public TaskResult Assert()
        {
            return new TaskResult(Name, issues =>
            {
                var lazyLoadResult = AssertLazyLoadSteps();
                issues.AddRange(lazyLoadResult.Issues);
            });
        }
    }
}
