using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.UI.Forms;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI.BootUserPrompt
{
    public partial class BootWizardControl : SIUserControl
    {
        //http://msdn.microsoft.com/en-us/library/x13ttww7.aspx
        private volatile bool _wizardFinished;
        public BootWizardControl()
        {
            InitializeComponent();
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


        public Task InitAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                _wizardFinished = false;
                while (!_wizardFinished)
                {
                    Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }

        private void btnAdvancedSetup_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void btnFullyAutomated_Click(object sender, EventArgs e)
        {
            Services.UserPreferences.Properties.ResetToDefaultSettings();
            Services.UserPreferences.Save();
            Services.Pipelines.Run<InitialSetupPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
            Finish();
        }

    }
}
