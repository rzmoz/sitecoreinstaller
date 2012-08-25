﻿using System;
using System.Threading;

using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;

    using SitecoreInstaller.Framework.Diagnostics;

    public class NothingPipeline : IPipeline
    {
        public IEnumerable<IPrecondition> Preconditions
        {
            get { return Enumerable.Empty<IPrecondition>(); }
        }

        public void Init()
        {
        }
        [Step(1, Run = Run.OnlyInUi)]
        public void DoNothing(object sender, EventArgs e)
        {
            Log.It.Info("Starting doing nothing...");
        }
        [Step(2)]
        public void DoNothingForAWhile(object sender, EventArgs e)
        {
            for (var i = 0; i < 10; i++)
                Log.It.Info("Logging...");
            Log.It.Info("Pinging the world!...");
            Thread.Sleep(200);
            Log.It.Debug("Debugging the world!...");
            Thread.Sleep(200);
            Log.It.Warning("Warning the world!...");
            Thread.Sleep(200);
            Log.It.Error("Erroring the world!");
        }
    }
}
