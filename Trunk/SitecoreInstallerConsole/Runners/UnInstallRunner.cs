﻿using System;

using SitecoreInstaller.App;

namespace SitecoreInstallerConsole.Runners
{
    using SitecoreInstaller.App.Pipelines;
    using SitecoreInstaller.Domain.Pipelines;

    public class UnInstallRunner : ConsolePipelineRunner
    {
        public UnInstallRunner(string[] args)
            : base(args)
        {
        }

        public override void Run()
        {
            if (Args[0] != ArgSwitches.UnInstall)
                throw new ArgumentException(string.Format("Wrong arguments provided. Was {0}", Args[0]));

            if (Args.Length != 2)
                throw new ArgumentException(string.Format("Wrong # of arguments. Expected 2. Was {0}", Args.Length));

            var projectName = Args[1];
            Services.AppSettings.ProjectName.Value = projectName;
            var pipeline = Services.Pipelines.Get<InstallPipeline>();
            pipeline.Pipeline.IsInUiMode = false;
            pipeline.ExecuateAllSteps(this, new EventArgs());
        }
    }
}
