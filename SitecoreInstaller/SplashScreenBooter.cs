using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller
{
    internal class SplashScreenBooter : Booter
    {
        public SplashScreenBooter(BasicsUserControl control)
            : base(control)
        {
        }

        public override Task<bool> InitAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(0.5)));//just to make sure splash screen is open long enough to be readable
                return false;
            });
        }
    }
}
