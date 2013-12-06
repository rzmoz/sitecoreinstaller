using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller
{
    internal class SplashScreenBooter : Booter
    {
        public SplashScreenBooter(SIUserControl control)
            : base(control)
        {
        }

        public override Task InitAsync()
        {
            return Task.Delay(TimeSpan.FromSeconds(0.5));//just to make sure splash screen is open long enough to be readable
        }
    }
}
