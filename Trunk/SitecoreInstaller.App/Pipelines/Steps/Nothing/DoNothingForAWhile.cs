﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
    using System.Threading;
    using System.Threading.Tasks;
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    public class DoNothingForAWhile : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Log.As.Info(typeof(SourceManifest).Name);
            for (var i = 0; i < 10; i++)
                Log.As.Info("Logging...");
            Log.As.Info("Pinging the world!...");
            Task.Delay(200);
            Log.As.Debug("Debugging the world!...");
            Task.Delay(200);
            Log.As.Warning("Warning the world!...");
            Task.Delay(200);
            Log.As.Error("Erroring the world!");
        }
    }
}
