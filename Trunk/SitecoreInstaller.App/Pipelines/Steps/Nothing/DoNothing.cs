using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
    using SitecoreInstaller.Framework.Diagnostics;

    public class DoNothing : Step
    {
        public DoNothing(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Log.It.Info("Starting doing nothing...");
        }
    }
}
