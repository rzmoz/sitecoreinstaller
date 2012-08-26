using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    public partial class StepWizardDialog : UserControl
    {
        private StepWizard _stepWizard;

        public StepWizardDialog()
        {
            InitializeComponent();
        }

        public void Start()
        {
            if (_stepWizard == null)
                throw new InvalidOperationException("Please call Init() first");

            _stepWizard.Start();
            Show();
            BringToFront();
        }

        public void Show(UserSettingsStep step)
        {
            if (_stepWizard == null)
                throw new InvalidOperationException("Please call Init() first");

            _stepWizard.Show(step);
            Show();
            BringToFront();
        }

        public void Init()
        {
            lblMarker.Hide();
            _stepWizard = new StepWizard();
            foreach (var step in _stepWizard)
            {
                step.Top = 0;
                step.Left = 0;
                step.Dock = DockStyle.Fill;
                Controls.Add(step);
            }
            _stepWizard.Init();
        }
    }
}
