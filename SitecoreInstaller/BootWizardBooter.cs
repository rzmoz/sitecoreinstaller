using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using SitecoreInstaller.UI.BootUserPrompt;
using SitecoreInstaller.UI.Viewport;

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
