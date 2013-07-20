namespace SitecoreInstaller.UI.Settings
{
  using System;
  using System.ComponentModel;
  using System.Windows.Forms;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.UI.Forms;
  using SitecoreInstaller.UI.Viewport;

  public class ShowHideSettingsButton : SISystemButton
  {
    private const string _toolTipWhenVisible = "Close Settings";
    private const string _toolTipWhenNotVisible = "Open Settings";

    public ShowHideSettingsButton()
    {
      this.Image = SettingsResources.Settings;
      this.ImageActive = SettingsResources.Settings_Active;
      this.Text = string.Empty;
      this.Click += this.ShowHidePreferenecsButton_Click;

      this.ToolTipTextDeActive = string.Empty;
      this.ToolTipTextActive = _toolTipWhenNotVisible;
    }

    public UserSettings UserSettings { get; private set; }

    public void Init(UserSettings userSettings, ToolTip toolTip = null)
    {
      if (userSettings == null) { throw new ArgumentNullException("userSettings"); }
      this.UserSettings = userSettings;
      base.Init(toolTip);      
      Services.PipelineWorker.AllStepsExecuting += this.PipelineWorker_AllStepsExecuting;
      Services.PipelineWorker.WorkerCompleted += this.PipelineWorker_WorkerCompleted;
      this.Activate();
    }

    private void PipelineWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Activate();
    }

    private void PipelineWorker_AllStepsExecuting(object sender, PipelineInfoEventArgs e)
    {
      this.DeActivate();
    }

    void ShowHidePreferenecsButton_Click(object sender, EventArgs e)
    {
      if (Services.PipelineWorker.IsBusy())
        return;
      var visible = ViewportStack.OpenOrCloseDependingOnCurrentState(this.UserSettings);
      if (visible)
        this.ToolTipTextActive = _toolTipWhenVisible;
      else
        this.ToolTipTextActive = _toolTipWhenNotVisible;
      this.Activate();
    }
  }
}
