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
        protected SIUserControl Control { get; private set; }

        public Task InitAsync()
        {
            Control.BringToFront();
            Control.Show();
            return TemplateInitAsync();
        }

        protected abstract Task TemplateInitAsync();

        public void Cleanup()
        {
            Control.SendToBack();
            Control.Hide();
        }
    }
}
