using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.Runtime.Install
{
    public class InstallPipeline : Pipeline<InstallArgs>
    {
        public InstallPipeline()
        {
            AddBlock("Init").AddStep<CreateInstallDirStep>();

            AddBlock("Copy Sitecore").AddStep<CopySitecoreStep>();
            AddBlock("Copy Modules").AddStep<CopySitecoreModulesStep>()
                                    .AddStep<CopySitecoreInstallerModulesStep>();

            AddBlock("Copy Runtime Files").AddStep<CopyRuntimeServicesStep>()
                                        .AddStep<CopyLicenseFileStep>();

            /*
            AddBlock("Configure Sitecore").AddStep<SetConnectionStringsStep>()
                                        .AddStep<SetDataFolderStep>()
                                        .AddStep<SetSitecoreSettingsStep>();

            AddBlock("Transform config files").AddStep<TransformConfigFilesStep>();

            AddBlock("Configure Website").AddStep<AttachDatabasesStep>()
                                        .AddStep<AddSitenameToHostfileStep>()
                                        .AddStep<CreateIisWebsiteStep>();

            AddBlock("Install Packages").AddStep<InstallPackagesStep>();

            AddBlock("Prepare desktop").AddStep<PrepareDesktopStep>();

            AddBlock("Transform config files").AddStep<TransformConfigFilesStep>();

            AddBlock("Warming up website");
            */
        }
    }
}
