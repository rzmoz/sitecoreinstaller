using System;
using System.Diagnostics;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Framework.Sys
{
    public static class CommandPrompt
    {
        public static CommandPromptResult Run(string commandFormat, params object[] args)
        {
            var command = string.Format(commandFormat, args);
            return Run(command, LogType.Error);
        }

        public static CommandPromptResult Run(string commandString, LogType logErrorAs = LogType.Error)
        {
            Log.As.Debug("Command prompt invoked: {0}", commandString);

            var si = new ProcessStartInfo("cmd.exe", "/c " + commandString)
            {
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (var console = new Process { StartInfo = si })
            {
                console.Start();

                var result = new CommandPromptResult
                {
                    StandardOutput = console.StandardOutput.ReadToEnd(),
                    StandardError = console.StandardError.ReadToEnd()
                };

                Log.As.Debug(result.StandardOutput);

                if (result.StandardError.Length > 0)
                    Log.As.As(logErrorAs, result.StandardError);

                console.Close();
                return result;
            }
        }
    }
}
