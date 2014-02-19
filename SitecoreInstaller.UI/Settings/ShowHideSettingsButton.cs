using System;
using System.ComponentModel;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.UI.Forms;

namespace SitecoreInstaller.UI.Settings
{
    public class ShowHideSettingsButton : SISystemButton
    {
        private const string _toolTipWhenVisible = "Close Settings";
        private const string _toolTipWhenNotVisible = "Open Settings";

        public ShowHideSettingsButton()
        {
            this.Image = SettingsResources.Settings;
            this.ImageActive = SettingsResources.Settings_Active;
            this.Text = string.Empty;
            this.ToolTipWhenVisible = _toolTipWhenVisible;
            this.ToolTipWhenNotVisible = _toolTipWhenNotVisible;
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
            Services.PipelineEngine.AllStepsExecuting += this.PipelineWorker_AllStepsExecuting;
            Services.PipelineEngine.PipelineCompleted+= this.PipelineWorker_WorkerCompleted;
            this.Activate();
        }

        private void PipelineWorker_WorkerCompleted(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void PipelineWorker_AllStepsExecuting(object sender, PipelineInfoEventArgs e)
        {
            this.DeActivate();
        }

        void ShowHidePreferenecsButton_Click(object sender, EventArgs e)
        {
            if (Services.PipelineEngine.IsBusy)
                return;
            this.OpenOrCloseControlDependingOnCurrentState(this.UserSettings);
            this.Activate();
        }
    }
}
