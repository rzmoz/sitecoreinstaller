﻿using System;
using System.Linq;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys;
using CSharp.Basics.Sys.Tasks;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.UI;

namespace SitecoreInstaller
{
    using System.Threading.Tasks;
    using Microsoft.WindowsAPICodePack.Taskbar;
    using App;
    using Domain.Pipelines;

    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CenterToScreen();

            Services.LoadUserPreferences();

            var booter = CreateBooter();

            mainCtrl1.BringToFront();

            UiServices.ViewportStack.Register(booter.Control);
            UiServices.ViewportStack.Show(booter.Control);

            Services.Init();

            Init();

            Task<bool> bootTask = booter.InitAsync();
            await bootTask;
            UiServices.ViewportStack.Hide(booter.Control);
            UiServices.ViewportStack.UnRegister(booter.Control);

            if (bootTask.Result)
                mainCtrl1.ShowUserPreferences();
            if (NeedLicense())
                mainCtrl1.GotoLicenses();

            await Task.Factory.StartNew(Services.SourceManifests.UpdateExternal);
        }
        private bool NeedLicense()
        {
            var licenses = Services.BuildLibrary.List(SourceType.License).Cast<LicenseFileSourceEntry>().Select(entry => entry.LicenseFile).ToList();
            var hasValidLicense = licenses.Any(license => !license.IsExpired);
            return !hasValidLicense;
        }
        private Booter CreateBooter()
        {
            if (Services.UserPreferences.Properties.PromptForUserSettings)
                return new BootWizardBooter(bootWizardControl1);
            else
                return new SplashScreenBooter(splashScreen1);
        }

        public void Init()
        {
            mainCtrl1.Init();

            Services.PipelineEngine.AllStepsExecuting += PipelineWorkerOnAllStepsExecuting;
            Services.PipelineEngine.StepExecuting += PipelineWorker_StepExecuting;
            Services.PipelineEngine.AllStepsExecuted += PipelineWorker_AllStepsExecuted;
        }

        private void PipelineWorkerOnAllStepsExecuting(object sender, PipelineInfoEventArgs pipelineInfoEventArgs)
        {
            if (!TaskbarManager.IsPlatformSupported)
                return;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
        }

        private void PipelineWorker_StepExecuting(object sender, PipelineStepInfoEventArgs e)
        {
            if (!TaskbarManager.IsPlatformSupported)
                return;

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            TaskbarManager.Instance.SetProgressValue(e.StepNumber - 1, e.TotalStepCount);
        }

        private void PipelineWorker_AllStepsExecuted(object sender, PipelineInfoEventArgs e)
        {
            if (!TaskbarManager.IsPlatformSupported)
                return;
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            Wait.For(3.Seconds());
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (mainCtrl1.ProcessKeyPress(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
