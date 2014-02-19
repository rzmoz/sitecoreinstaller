using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;

namespace SitecoreInstaller.UI.BootUserPrompt
{
    public partial class BootWizardControl : BasicsUserControl
    {
        private readonly InputTask<bool> _waitForInputTask;

        public BootWizardControl()
        {
            InitializeComponent();
            _waitForInputTask = new InputTask<bool>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BackColor = Styles.Theme.Dark.Controls.BackColor;
            InitButtons(btnAdvancedSetup, btnFullyAutomated);
        }

        private void InitButtons(params Button[] buttons)
        {
            Parallel.ForEach(buttons, button =>
            {
                button.BackColor = Styles.Navigation.Level1.BackColor;
                button.ForeColor = Styles.Navigation.Level1.ForeColor;
                button.FlatAppearance.BorderSize = 3;
                button.FlatAppearance.BorderColor = Styles.Navigation.Level1.ForeColor;
                button.Font = Styles.Fonts.H1;
            });
        }

        public Task<bool> InitAsync()
        {
            return _waitForInputTask.WaitForInputAsync(() =>
            {
                Services.UserPreferences.Properties.PromptForUserSettings = false;
                Services.UserPreferences.Save();
            });
        }

        private void btnAdvancedSetup_Click(object sender, EventArgs e)
        {
            _waitForInputTask.SetResult(false);
        }

        private async void btnFullyAutomated_Click(object sender, EventArgs e)
        {
            Services.UserPreferences.Properties.ResetToDefaultSettings();
            Services.UserPreferences.Save();
            UiServices.ViewportStack.Hide(this);
            await Services.Pipelines.RunAsync<AutoSetupPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
            _waitForInputTask.SetResult(true);
        }

    }
}
