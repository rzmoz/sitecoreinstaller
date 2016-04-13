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

namespace SitecoreInstaller.UI.Settings
{
    public partial class AutoSetupSettings : UserSettingsCtrl
    {
        public AutoSetupSettings()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            Label = "Auto Setup";
            SaveButton.Visible = false;
        }

        private async void btnFullyAutomated_Click(object sender, EventArgs e)
        {
            await Services.Pipelines.RunAsync<AutoSetupPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
        }
    }
}
