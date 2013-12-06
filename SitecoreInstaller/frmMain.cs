﻿using System;
using System.Windows.Forms;

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

            splashScreen1.Show();
            splashScreen1.BringToFront();


            Services.Init();

            Init();
            //awaits must be place after init methods, since it messes with the ui thread.
            await Task.Delay(TimeSpan.FromSeconds(0.5));//just to make sure splash screen is open long enough to be readable

            splashScreen1.Hide();
            splashScreen1.SendToBack();
            splashScreen1.Stop();

            await Task.Factory.StartNew(Services.SourceManifests.UpdateExternal);
        }

        public void Init()
        {
            mainCtrl1.Init();

            Services.PipelineWorker.AllStepsExecuting += PipelineWorkerOnAllStepsExecuting;
            Services.PipelineWorker.StepExecuting += PipelineWorker_StepExecuting;
            Services.PipelineWorker.AllStepsExecuted += PipelineWorker_AllStepsExecuted;
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
            Task.WaitAll(Task.Delay(3000));
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
