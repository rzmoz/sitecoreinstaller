using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys;
using CSharp.Basics.Sys.Tasks;

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
                Wait.For(500.MilliSeconds());//just to make sure splash screen is open long enough to be readable
                return false;
            });
        }
    }
}
