namespace SitecoreInstaller.Framework.System
{
    using global::System.Diagnostics;

    public class CommandPrompt
    {
        public DataReceivedEventHandler OutputDataRecieved;
        public DataReceivedEventHandler ErrorDataRecieved;

        public void Run(string commandString)
        {
            Diagnostics.Log.As.Debug("Command prompt called: {0}", commandString);

            var si = new ProcessStartInfo("cmd.exe", "/c " + commandString)
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using (var console = new Process { StartInfo = si })
            {
                console.OutputDataReceived += OutputDataRecieved;
                console.ErrorDataReceived += ErrorDataRecieved;

                console.Start();

                console.BeginErrorReadLine();
                console.BeginOutputReadLine();
                console.WaitForExit();
                console.Close();
            }
        }
    }
}
