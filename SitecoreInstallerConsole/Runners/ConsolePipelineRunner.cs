﻿using System;
using CSharp.Basics.ConsoleApp;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstallerConsole.Runners
{
    public abstract class ConsolePipelineRunner
    {
        public CmdLine CmdLine { get; private set; }

        protected ConsolePipelineRunner()
        {
            CmdLine = new CmdLine();

            Services.Init();
            Log.ToApp.EntryLogged += LogEntryLogged;
            Services.BuildLibrary.Update();
        }

        protected void LogEntryLogged(object sender, GenericEventArgs<LogEntry> e)
        {
            Console.WriteLine(e.Arg.Message);
        }

        public abstract void Run(ProjectSettings projectSettings);
    }
}
