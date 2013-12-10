using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Databases
{
    public static class SqlServerPrompt
    {
        private const string _commandFormat = @"net {0} ""SQL SERVER ({1})""";
        private const string _startSwitch = @" stop ";
        private const string _stopSwitch = @" start ";

        public static void StartServer(string instanceName)
        {
            if (instanceName == null) throw new ArgumentNullException("instanceName");
            CommandPrompt.Run(_commandFormat, _startSwitch, instanceName);
        }
        public static void StopServer(string instanceName)
        {
            if (instanceName == null) throw new ArgumentNullException("instanceName");
            CommandPrompt.Run(_commandFormat, _stopSwitch, instanceName);
        }
    }
}
