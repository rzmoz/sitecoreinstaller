using CSharp.Basics.Pipelines;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class InstallPipeline : TaskPipeline<InstallArgs>
    {
        public InstallPipeline()
        {
            AddBlock("Generate Install Values").AddStep<SetInstallArgsValuesStep>();
        }
    }
}
