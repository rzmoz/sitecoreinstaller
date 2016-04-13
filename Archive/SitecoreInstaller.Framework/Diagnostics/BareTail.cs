using System.Diagnostics;
using System.IO;
using System.Linq;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public static class BareTail
    {
        private const string _fileName = @"baretail.exe";

        public static void OpenLogs(params FileInfo[] logFiles)
        {
            if (logFiles == null)
                return;
            if (logFiles.Length == 0)
                return;

            var sortedLogFiles = logFiles.OrderByDescending(logFile => logFile.Name.GetNumbers());

            var logFileNames = string.Empty;
            foreach (var logFile in sortedLogFiles)
            {
                logFileNames += string.Format(@" ""{0}""", logFile.FullName);
            }

            ExternalProcess.Run(_fileName, logFileNames);
        }
    }
}
