using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.UI.BootUserPrompt;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller
{
    internal abstract class Booter
    {
        protected Booter(BasicsUserControl control)
        {
            Control = control;
        }
        public BasicsUserControl Control { get; private set; }

        public abstract Task<bool> InitAsync();

    }
}
