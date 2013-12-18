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
            this.Label = "Auto Setup";
        }

        private void btnFullyAutomated_Click(object sender, EventArgs e)
        {
            Services.Pipelines.Run<AutoSetupPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
        }
    }
}
