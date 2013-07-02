namespace SitecoreInstaller.Framework.System
{
  using global::System.Diagnostics;

  public class CommandPrompt
  {
    public CommandPromptResult Run(string commandFormat, params object [] args)
    {
      var command = string.Format(commandFormat, args);
      return Run(command);
    }
    public CommandPromptResult Run(string commandString)
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

        var result = new CommandPromptResult
        {
          StandardOutput = console.StandardOutput.ReadToEnd(),
          StandardError = console.StandardError.ReadToEnd()
        };

        if (result.StandardError.Length > 0)
          Diagnostics.Log.This.Error(result.StandardError);

        console.Close();
        return result;
      }
    }
  }
}
