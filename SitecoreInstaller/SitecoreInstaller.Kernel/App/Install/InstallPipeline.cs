using CSharp.Basics.Pipelines;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class InstallPipeline : TaskPipeline<InstallArgs>
    {
        public InstallPipeline()
        {
            AddBlock("Generate Install Values").AddStep<SetInstallArgsValuesStep>();
            AddBlock("Prepare wwwroot").AddStep<CreateTargetRootDirStep>();
            AddBlock("Copy sitecore").AddStep<CopySitecoreStep>();
            AddBlock("Copy license").AddStep<CopyLicenseFileStep>();
            AddBlock("Copy modules").AddStep<CopySitecoreModulesStep>()
                                    .AddStep<CopySitecoreInstallerModulesStep>();

        }
    }
}
