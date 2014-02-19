using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.AutoSetup
{
    public partial class StepWizard : UserControl
    {
        private IList<StepWizardStep> _steps;

        public StepWizard()
        {
            InitializeComponent();
            _steps = new List<StepWizardStep>();
            WizardFinished = false;
        }

        public Task<bool> StartWizard()
        {
            WizardFinished = false;
            Visible = true;
            BringToFront();
            return Task.Factory.StartNew(() =>
            {
                while (!WizardFinished)
                    Task.WaitAll(Task.Delay(100));
                return true;
            });
        }

        public bool WizardFinished { get; private set; }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

        }
    }
}
