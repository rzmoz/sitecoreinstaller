﻿using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class InstallPipeline : TaskPipeline<InstallArgs>
    {
        public InstallPipeline()
        {
            AddBlock("Generate Install Values").AddStep<SetInstallArgsValuesStep>();

            AddBlock("Prepare Wwwroot").AddStep<CreateInstallDirStep>();

            AddBlock("Copy Sitecore").AddStep<CopySitecoreStep>();
            AddBlock("Copy Modules").AddStep<CopySitecoreModulesStep>()
                                    .AddStep<CopySitecoreInstallerModulesStep>();

            AddBlock("Copy Runtime Files").AddStep<CopyRuntimeServicesStep>()
                                        .AddStep<CopyLicenseFileStep>();

            AddBlock("Configure Sitecore").AddStep<SetConnectionStringsStep>()
                                        .AddStep<SetDataFolderStep>()
                                        .AddStep<SetSitecoreSettingsStep>();

            AddBlock("Transform config files").AddStep<TransformConfigFilesStep>();

            AddBlock("Configure Website").AddStep<AttachDatabasesStep>()
                                        .AddStep<AddSitenameToHostfileStep>()
                                        .AddStep<CreateIisWebsiteStep>();

            AddBlock("Install Packages").AddStep<InstallPackagesStep>();

            AddBlock("Prepare desktop").AddStep<PrepeareDesktopStep>();

            AddBlock("Transform config files").AddStep<TransformConfigFilesStep>();

            AddBlock("Warming up website");
        }
    }
}
