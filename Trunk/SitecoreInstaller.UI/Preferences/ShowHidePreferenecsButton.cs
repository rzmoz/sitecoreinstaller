using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.UI.Preferences
{
  using System.ComponentModel;
  using System.Windows.Forms;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.UI.Forms;
  using SitecoreInstaller.UI.Viewport;

  public class ShowHidePreferenecsButton : SISystemButton
  {
    public ShowHidePreferenecsButton()
    {
      this.Image = PreferencesResources.Settings;
      this.ImageActive = PreferencesResources.Settings_Active;
      this.Text = string.Empty;
      this.Click += ShowHidePreferenecsButton_Click;

      ToolTipTextDeActive = string.Empty;
      ToolTipTextActive = "Open preferences";
    }

    public UserPreferences UserPreferences { get; private set; }

    public void Init(UserPreferences userPreferences, ToolTip toolTip = null)
    {
      if (userPreferences == null) { throw new ArgumentNullException("userPreferences"); }
      UserPreferences = userPreferences;
      base.Init(toolTip);      
      Services.PipelineWorker.AllStepsExecuting += PipelineWorker_AllStepsExecuting;
      Services.PipelineWorker.WorkerCompleted += PipelineWorker_WorkerCompleted;
      this.Activate();
    }

    private void PipelineWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.Activate();
    }

    private void PipelineWorker_AllStepsExecuting(object sender, PipelineEventArgs e)
    {
      this.DeActivate();
    }

    void ShowHidePreferenecsButton_Click(object sender, EventArgs e)
    {
      if (Services.PipelineWorker.IsBusy())
        return;
      var visible = ViewportStack.OpenOrCloseDependingOnCurrentState(UserPreferences);
      if (visible)
        ToolTipTextActive = "Close preferences";
      else
        ToolTipTextActive = "Open preferences";
      this.Activate();
    }
  }
}
