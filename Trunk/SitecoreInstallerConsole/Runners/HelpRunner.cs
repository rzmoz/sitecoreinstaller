using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstallerConsole.Runners
{
    public class HelpRunner : IConsoleRunner
    {
        public void Run()
        {
            Console.WriteLine("SitecoreInstaller console application help");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Main switches - there can be only one. Main switches can have sub parameters");
            Console.WriteLine(string.Empty);
            Console.WriteLine("{0}:\t\tprint this help", ArgSwitches.Help);
            Console.WriteLine("{0}:\t\tlist Sitecore's and modules", ArgSwitches.List);
            Console.WriteLine("{0}:\tinstall clean project", ArgSwitches.Install);
            Console.WriteLine("{0}:\tuninstall project", ArgSwitches.UnInstall);
            Console.WriteLine("{0}:\treinstall project", ArgSwitches.ReAttach);
        }
    }
}
