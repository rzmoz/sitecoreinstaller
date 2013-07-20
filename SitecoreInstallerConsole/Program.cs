﻿using System;
using SitecoreInstallerConsole.Runners;

namespace SitecoreInstallerConsole
{
  using System.Threading;
  using System.Threading.Tasks;
  using SitecoreInstaller.App;

  class Program
  {
    static void Main(string[] args)
    {
      var consoleRunnerFactory = new ConsoleRunnerFactory();
      var runner = consoleRunnerFactory.Create(args) ?? new HelpRunner(args);
      runner.CmdLine.Parse(args);

      var projectSettings = new ProjectSettings();
      projectSettings.Init(Services.UserPreferences.Properties);

      runner.Run(projectSettings);

      while (Services.PipelineWorker.IsBusy())
      {
        Task.WaitAll(Task.Delay(1000));
      }
    }
  }
}
