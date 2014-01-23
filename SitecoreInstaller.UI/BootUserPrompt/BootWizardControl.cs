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
        //http://msdn.microsoft.com/en-us/library/x13ttww7.aspx
        private volatile bool _wizardFinished;

        private volatile bool _showUserPreferences;

        public BootWizardControl()
        {
            InitializeComponent();
            _showUserPreferences = false;
        }

        private void Finish()
        {
            _wizardFinished = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BackColor = Styles.Controls.BackColor;
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
            return Task.Factory.StartNew(() =>
            {
                _wizardFinished = false;
                while (!_wizardFinished)
                {
                    Task.Delay(TimeSpan.FromSeconds(1));
                }
                Services.UserPreferences.Properties.PromptForUserSettings = false;
                Services.UserPreferences.Save();
                return _showUserPreferences;
            });
        }

        private void btnAdvancedSetup_Click(object sender, EventArgs e)
        {
            _showUserPreferences = true;
            Finish();
        }

        private void btnFullyAutomated_Click(object sender, EventArgs e)
        {
            Services.UserPreferences.Properties.ResetToDefaultSettings();
            Services.UserPreferences.Save();
            Services.Pipelines.Run<AutoSetupPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
            Finish();
        }

    }
}
