using System;
using SitecoreInstallerConsole.Runners;

namespace SitecoreInstallerConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("SitecoreInstaller starting...");
      Console.Read();

      var consoleRunnerFactory = new ConsoleRunnerFactory();
      var runner = consoleRunnerFactory.Create(args) ?? new HelpRunner(args);
      runner.CmdLine.Parse(args);
      runner.Run();
    }
  }
}
