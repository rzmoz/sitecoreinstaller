using System;
using SitecoreInstallerConsole.Runners;

namespace SitecoreInstallerConsole
{
  using System.Threading;
  using SitecoreInstaller.App;

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Press key to start...");
      Console.Read();

      var consoleRunnerFactory = new ConsoleRunnerFactory();
      var runner = consoleRunnerFactory.Create(args) ?? new HelpRunner(args);
      runner.CmdLine.Parse(args);
      runner.Run();

      while (Services.PipelineWorker.IsBusy())
      {
        Thread.Sleep(1000);
      }
    }
  }
}
