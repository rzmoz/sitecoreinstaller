using System;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Databases
{
    public static class SqlServerPrompt
    {
        private const string _commandFormat = @"net {0} ""SQL SERVER ({1})""";
        private const string _startSwitch = @" start ";
        private const string _stopSwitch = @" stop ";

        public static int StartServer(string instanceName)
        {
            if (instanceName == null) throw new ArgumentNullException(nameof(instanceName));
            var cmd = string.Format(_commandFormat, _startSwitch, instanceName);
            return CommandPrompt.Run(cmd);
        }

        public static int StopServer(string instanceName)
        {
            if (instanceName == null) throw new ArgumentNullException(nameof(instanceName));
            var cmd = string.Format(_commandFormat, _stopSwitch, instanceName);
            return CommandPrompt.Run(cmd);
        }
    }
}
