namespace SitecoreInstaller.Framework.Scripting
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Management.Automation;
  using System.Text;

  public class PowerShellRunner
  {
    public string RunPowerShellFunction(string method, KeyValuePair<string, object> arg, string scriptPath)
    {
      if (method == null) { throw new ArgumentNullException("method"); }
      if (scriptPath == null) { throw new ArgumentNullException("scriptPath"); }
      var scriptFullPath = Path.GetFullPath(scriptPath);

      if (File.Exists(scriptFullPath) == false)
        throw new ArgumentException("Script not found at:" + scriptPath);

      using (var ps = PowerShell.Create())
      {
        ps.AddScript(". '" + scriptFullPath + "'", false);
        ps.Invoke();

        ps.Commands.Clear();

        ps.AddCommand(method).AddParameter(arg.Key, arg.Value);

        var results = ps.Invoke();

        var resultString = new StringBuilder();

        foreach (var psObject in results)
        {
          resultString.Append(psObject + Environment.NewLine);
        }

        return resultString.ToString().TrimEnd(Environment.NewLine.ToCharArray());
      }
    }
  }
}
