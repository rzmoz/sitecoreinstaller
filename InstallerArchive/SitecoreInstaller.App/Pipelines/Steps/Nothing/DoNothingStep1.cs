using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CSharp.Basics.Sys;
using CSharp.Basics.Sys.Tasks;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Web;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
    public class DoNothingStep1 : Step<DoNothingEventArgs>
    {
        protected override void InnerInvoke(object sender, DoNothingEventArgs args)
        {
            //Wait.For(1.Seconds());
            Log.As.Info("User selected: " + args.UserAccepted);
        }
    }
}
