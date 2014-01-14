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
            var wizardcontrol = Control as BootWizardControl;
            if (wizardcontrol == null)
                throw new ApplicationException("not the right type. This shouldn't be possible");
            return wizardcontrol.InitAsync();
        }
    }
}
