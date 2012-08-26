using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
    using System.Threading;

    using SitecoreInstaller.Framework.Diagnostics;

    public class DoNothingForAWhile : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            for (var i = 0; i < 10; i++)
                Log.ItAs.Info("Logging...");
            Log.ItAs.Info("Pinging the world!...");
            Thread.Sleep(200);
            Log.ItAs.Debug("Debugging the world!...");
            Thread.Sleep(200);
            Log.ItAs.Warning("Warning the world!...");
            Thread.Sleep(200);
            Log.ItAs.Error("Erroring the world!");
        }
    }
}
