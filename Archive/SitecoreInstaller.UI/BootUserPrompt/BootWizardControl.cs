using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys.Tasks;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;

namespace SitecoreInstaller.UI.BootUserPrompt
{
    public partial class BootWizardControl : BasicsUserControl
    {
        private readonly AwaitTask<bool> _waitForInputTask;

        public BootWizardControl()
        {
            InitializeComponent();
            _waitForInputTask = new AwaitTask<bool>();
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
            return _waitForInputTask.AwaitAsync(() =>
            {
                Services.UserPreferences.Properties.PromptForUserSettings = false;
                Services.UserPreferences.Save();
            });
        }

        private void btnAdvancedSetup_Click(object sender, EventArgs e)
        {
            _waitForInputTask.IsDone(true);
        }

        private async void btnFullyAutomated_Click(object sender, EventArgs e)
        {
            Services.UserPreferences.Properties.ResetToDefaultSettings();
            Services.UserPreferences.Save();
            UiServices.ViewportStack.Hide(this);
            await Services.Pipelines.RunAsync<AutoSetupPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
            _waitForInputTask.IsDone(false);
        }
    }
}
