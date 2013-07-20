using System.Windows.Forms;

namespace SitecoreInstaller
{
  using System;
  using System.Threading;
  using Microsoft.WindowsAPICodePack.Taskbar;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.Pipelines;

  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.CenterToScreen();
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
      Thread.Sleep(3000);
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
