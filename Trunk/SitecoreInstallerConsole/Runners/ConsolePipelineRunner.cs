using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.App;

namespace SitecoreInstallerConsole.Runners
{
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;

    public abstract class ConsolePipelineRunner : IConsoleRunner
    {
        protected ConsolePipelineRunner(string[] args)
        {
            Args = args;
            Services.Init();
            Log.As.EntryLogged += LogEntryLogged;
            Services.AppSettings = new AppSettings();
            Services.AppSettings.Init(UserSettings.Default);
            Services.BuildLibrary.Update();
        }

        protected void LogEntryLogged(object sender, GenericEventArgs<LogEntry> e)
        {
            Console.WriteLine(e.Arg.Message);
        }

        public abstract void Run();

        protected string[] Args { get; set; }
    }
}
