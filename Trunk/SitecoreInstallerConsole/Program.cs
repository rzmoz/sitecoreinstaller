using System;
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
      runner.Run();

      while (Services.PipelineWorker.IsBusy())
      {
        Task.Delay(1000);
      }
    }
  }
}
