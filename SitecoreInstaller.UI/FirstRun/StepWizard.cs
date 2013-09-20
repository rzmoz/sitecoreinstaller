using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.FirstRun
{
    public partial class StepWizard : UserControl
    {
        public StepWizard()
        {
            InitializeComponent();
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

        private void siButton1_Click(object sender, EventArgs e)
        {
            WizardFinished = true;
        }
    }
}
