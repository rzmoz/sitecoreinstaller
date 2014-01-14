using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Databases
{
    public static class SqlServerPrompt
    {
        private const string _commandFormat = @"net {0} ""SQL SERVER ({1})""";
        private const string _startSwitch = @" start ";
        private const string _stopSwitch = @" stop ";

        public static CommandPromptResult StartServer(string instanceName, LogType logErrorAs = LogType.Error)
        {
            if (instanceName == null) throw new ArgumentNullException("instanceName");
            var cmd = string.Format(_commandFormat, _startSwitch, instanceName);
            return CommandPrompt.Run(cmd, logErrorAs);
        }

        public static CommandPromptResult StopServer(string instanceName, LogType logErrorAs = LogType.Error)
        {
            if (instanceName == null) throw new ArgumentNullException("instanceName");
            var cmd = string.Format(_commandFormat, _stopSwitch, instanceName);
            return CommandPrompt.Run(cmd, logErrorAs);
        }
    }
}
