using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    public class DoNothing : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Log.As.Info("Starting doing nothing...");
        }
    }
}
