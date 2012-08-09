using System;

namespace SitecoreInstallerConsole.Runners
{
    public class ConsoleRunnerFactory
    {
        public IConsoleRunner Create(string[] args)
        {
            if (args == null || args.Length == 0)
                return new HelpRunner();
            var mainSwitch = args[0];

            switch (mainSwitch)
            {
                case ArgSwitches.List:
                    return new ListRunner(args);
                case ArgSwitches.Install:
                    return new InstallRunner(args);
                case ArgSwitches.UnInstall:
                    return new UnInstallRunner(args);
                case ArgSwitches.ReAttach:
                    return new ReAttachRunner(args);
                default:
                    return new HelpRunner();
            }
        }
    }
}
