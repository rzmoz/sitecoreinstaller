using System.Diagnostics;

namespace SitecoreInstaller.Framework.Sys
{
  public static class ExternalProcess
  {
    public static void Run(string fileName, string arguments)
    {
      var si = new ProcessStartInfo(fileName, arguments)
      {
        RedirectStandardInput = false,
        RedirectStandardOutput = false,
        RedirectStandardError = false,
        UseShellExecute = false,
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden
      };
      using (var process = new Process { StartInfo = si })
      {
        process.Start();
        process.Close();
      }
    }
  }
}
