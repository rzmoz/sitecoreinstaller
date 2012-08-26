using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller
{
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.System;
    using SitecoreInstaller.UI;
    using SitecoreInstaller.UI.UserSettingsDialogs;

    public partial class FrmUserSettings : Form
    {
        public FrmUserSettings()
        {
            InitializeComponent();
            StepWizard = new StepWizard();
            foreach (var step in StepWizard)
            {
                step.Top = 0;
                step.Left = 0;
                step.Dock = DockStyle.Fill;
                Controls.Add(step);
            }
        }

        public StepWizard StepWizard { get; private set; }

        public void Init()
        {
            StepWizard.Init();
        }
    }
}
