using System;
using System.Threading.Tasks;
using SitecoreInstaller.UI.BootUserPrompt;

namespace SitecoreInstaller
{
    internal class BootWizardBooter : Booter
    {
        public BootWizardBooter(BootWizardControl control)
            : base(control)
        {
        }

        public override Task<bool> InitAsync()
        {
            var wizardcontrol = (BootWizardControl)Control;
            return wizardcontrol.InitAsync();
        }
    }
}
