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
        public ListRunner(string[] args)
            : base(args)
        {
        }

        public override void Run()
        {
            Console.WriteLine("**** Sitecore ***********************************");
            foreach (var sitecore in Services.BuildLibrary.List(SourceType.Sitecore))
            {
                Console.WriteLine("{0} [{1}]", sitecore.Key, sitecore.SourceName);
            }
            Console.WriteLine("**** Licenses ******************************");
            foreach (var license in Services.BuildLibrary.List(SourceType.License))
            {
                Console.WriteLine("{0} [{1}]", license.Key, license.SourceName);
            }
            Console.WriteLine("**** Modules *******************************");
            foreach (var module in Services.BuildLibrary.List(SourceType.Module))
            {
                Console.WriteLine("{0} [{1}]", module.Key, module.SourceName);
            }
        }
    }
}
