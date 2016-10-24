using Autofac;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallPipeline : Pipeline<InstallEventArgs>
    {
        public InstallPipeline(IContainer container) : base(container)
        {
            AddStep<InitDeploymentDirStep>();
            AddStep<CopyDeploymentFilesStep>();
            AddStep<InitConnectionStringsStep>();
            AddStep<AttacSqlhDatabasesStep>();
        }
    }
}
