using Autofac;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallPipeline : Pipeline<UnInstallArgs>
    {
        public UnInstallPipeline(IContainer container) : base(container)
        {
            AddStep<DeleteProjectDirStep>();
        }
    }
}
