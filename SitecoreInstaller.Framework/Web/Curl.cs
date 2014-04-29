using System.IO;
using CSharp.Basics.IO;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Web
{
    public static class Curl
    {
        private const string _fileName = @"curl.exe  -s -S"; //with only show errors switches
        private const string _downloadFormat = @" -o ""{0}"" ""{1}""";

        /// <summary>
        /// Do not use for files smaller than 1KB!
        /// </summary>
        /// <param name="fullyQualifiedUrl"></param>
        /// <param name="targetFile"></param>
        public static void Download(string fullyQualifiedUrl, FileInfo targetFile)
        {
            Log.ToApp.Info("Downloading: " + targetFile.Name);
            Log.ToApp.Debug("Downloading: " + fullyQualifiedUrl);
            var tempFile = new FileInfo(Path.GetTempFileName());
            var cmd = _fileName + string.Format(_downloadFormat, tempFile, fullyQualifiedUrl.Replace(" ", "%20"));

            CommandPrompt.Run(cmd);

            tempFile.Refresh();
            //download didn't succeeded
            if (tempFile.Length < 1024)
            {
                tempFile.Delete();
                Log.ToApp.Error("Failed to download:{0}", fullyQualifiedUrl);
                return;
            }
            targetFile.TryDelete();

            tempFile.MoveTo(targetFile.FullName);
        }
    }
}
