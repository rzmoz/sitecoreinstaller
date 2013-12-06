using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void siButton1_Click(object sender, EventArgs e)
        {
            _wizardFinished = true;
        }
    }
}
