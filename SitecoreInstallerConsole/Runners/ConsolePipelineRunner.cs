﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.App;

namespace SitecoreInstallerConsole.Runners
{
  using System.Threading.Tasks;
  using SitecoreInstaller.Framework.CmdArgs;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Sys;

  public abstract class ConsolePipelineRunner
  {
    public CmdLine CmdLine { get; private set; }

    protected ConsolePipelineRunner()
    {
      this.CmdLine = new CmdLine();
      
      Services.Init();
      Log.This.EntryLogged += LogEntryLogged;
      Services.BuildLibrary.Update();
    }

    protected void LogEntryLogged(object sender, GenericEventArgs<LogEntry> e)
    {
      Console.WriteLine(e.Arg.Message);
    }

    public abstract void Run(ProjectSettings projectSettings);
  }
}
