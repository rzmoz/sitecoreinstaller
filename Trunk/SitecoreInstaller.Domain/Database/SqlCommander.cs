using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace SitecoreInstaller.Domain.Database
{
    using SitecoreInstaller.Framework.Diagnostics;

    internal class SqlCommander
    {
        private readonly ILog _log;

        public SqlCommander(ILog log)
        {
            _log = log;
        }

        public void ExecuteTSqlScript(FileInfo scriptPath, string sqlInstanceName)
        {
            _log.Debug("Executing '{0}' against '{1}'", scriptPath.Name, sqlInstanceName);

            var arguments = string.Format(_ArgumentsFormat, sqlInstanceName, scriptPath.FullName);
            using (var transformProcess = new Process())
            {
                transformProcess.StartInfo.FileName = SqlCmdPath;
                transformProcess.StartInfo.Arguments = arguments;
                transformProcess.StartInfo.RedirectStandardOutput = true;
                transformProcess.StartInfo.RedirectStandardError = true;
                transformProcess.StartInfo.UseShellExecute = false;
                transformProcess.StartInfo.CreateNoWindow = true;
                try
                {
                    transformProcess.Start();
                    transformProcess.WaitForExit(60000); //we wait for a max 1 minute
                    //get output from transform task
                    _log.Debug(transformProcess.StandardOutput.ReadToEnd());
                }
                catch (Win32Exception e)
                {
                    _log.Error("Win32Exception occured when trying to run sqlcmd.exe.\r\nPath to SqlCmd.exe: {0}\r\nException:{1}", SqlCmdPath, e.ToString());
                }
            }
        }

        private const string _ArgumentsFormat = @" -S {0} -i {1}";

        private static string SqlCmdPath
        {
            get
            {
                var registryView = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                RegistryKey registryKey = registryView.OpenSubKey(SqlCmdRegEditKeyName);
                if (registryKey == null)
                    registryView = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);

                registryKey = registryView.OpenSubKey(SqlCmdRegEditKeyName);
                if (registryKey == null)
                    return SqlCmdExeName;

                var value = registryKey.GetValue(@"Path").ToString();
                if (value.Length > 0)
                    return Path.Combine(value, SqlCmdExeName);
                return SqlCmdExeName;
            }
        }
        const string SqlCmdRegEditKeyName = @"SOFTWARE\Microsoft\Microsoft SQL Server\100\Tools\ClientSetup";
        const string SqlCmdExeName = @"SqlCmd.exe";
    }
}
