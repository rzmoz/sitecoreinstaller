using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstallerConsole.Runners
{
    public class ListRunner : ConsolePipelineRunner
    {
        public ListRunner()
        {
            CmdLine.RegisterParameter(SitecoreInstallerParameters.List);
        }

        public override void Run(ProjectSettings projectSettings)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("**** Sitecore ***********************************");
            Console.WriteLine(string.Empty);
            foreach (var sitecore in Services.BuildLibrary.List(SourceType.Sitecore))
            {
                Console.WriteLine("{0} [{1}]", sitecore.Key, sitecore.SourceName);
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine("**** Licenses ******************************");
            Console.WriteLine(string.Empty);
            foreach (var license in Services.BuildLibrary.List(SourceType.License))
            {
                Console.WriteLine("{0} [{1}]", license.Key, license.SourceName);
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine("**** Modules *******************************");
            Console.WriteLine(string.Empty);
            foreach (var module in Services.BuildLibrary.List(SourceType.Module))
            {
                Console.WriteLine("{0} [{1}]", module.Key, module.SourceName);
            }
            Console.WriteLine(string.Empty);
        }
    }
}
