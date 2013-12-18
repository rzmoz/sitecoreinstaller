using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.UI.BootUserPrompt;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller
{
    internal abstract class Booter
    {
        protected Booter(SIUserControl control)
        {
            Control = control;
        }
        public SIUserControl Control { get; private set; }

        public abstract Task<bool> InitAsync();

    }
}
