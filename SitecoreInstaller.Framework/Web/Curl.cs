using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Web
{
  public static class Curl
  {
    private const string _FileName = @"curl.exe  -s -S"; //with only show errors switches
    private const string _DownloadFormat = @" -o ""{0}"" ""{1}""";

    public static void Download(string fullyQualifiedUrl, FileInfo targetFile)
    {
      Log.This.Info("Downloading: " + targetFile.Name);
      Log.This.Debug("Downloading: " + fullyQualifiedUrl);
      var tempFile = new FileInfo(Path.GetTempFileName());
      var cmd = _FileName + string.Format(_DownloadFormat, tempFile, fullyQualifiedUrl.Replace(" ", "%20"));

      CommandPrompt.Run(cmd);

      tempFile.Refresh();
      //download didn't succeeded
      if (tempFile.Length < 1024)
      {
        tempFile.Delete();
        Log.This.Error("Failed to download:{0}", fullyQualifiedUrl);
        return;
      }
      targetFile.Refresh();
      if (targetFile.Exists)
        targetFile.Delete();

      tempFile.MoveTo(targetFile.FullName);
    }
  }
}
