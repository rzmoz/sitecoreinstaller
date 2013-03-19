namespace SitecoreInstaller.Framework.System
{
    using global::System.Diagnostics;

    public class CommandPrompt
    {
        public void Run(string commandString)
        {
            Diagnostics.Log.This.Debug("Command prompt invoked: {0}", commandString);

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

                console.StandardOutput.ReadToEnd();
                var error = console.StandardError.ReadToEnd();
                if (error.Length > 0)
                    Diagnostics.Log.This.Error(error);

                console.Close();
            }
        }

    }
}
