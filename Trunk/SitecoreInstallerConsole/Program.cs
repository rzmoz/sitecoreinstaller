using SitecoreInstallerConsole.Runners;


namespace SitecoreInstallerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleRunnerFactory = new ConsoleRunnerFactory();
            var runner = consoleRunnerFactory.Create(args);
            runner.Run();
        }
    }
}
