using System;
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

            Booter booter = null;
            if (Services.UserPreferences.Properties.PromptForUserSettings)
                booter = new BootWizardBooter(bootWizardControl1);
            else
                booter = new SplashScreenBooter(splashScreen1);
            Task bootTask = booter.InitAsync();

            Services.Init();

            Init(); //awaits must be place after init methods, since it messes with the ui thread.

            await bootTask;
            
            mainCtrl1.BringToFront();

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
