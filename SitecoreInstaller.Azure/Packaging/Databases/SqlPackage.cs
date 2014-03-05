using System;
using System.IO;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Azure.Packaging.Databases
{
    public static class SqlPackage
    {
        private const string _fileName = @"sqlpackage.exe";

        private const string _exportSwitchesFormat = @" /tf:"".\{0}.bacpac"" /SourceConnectionString:""{1}"" /action:Export";

        public static void CreateBacpac(FileInfo bacpacFile, string connectionString)
        {
            if (bacpacFile == null) throw new ArgumentNullException("bacpacFile");
            if (connectionString == null) throw new ArgumentNullException("connectionString");
            bacpacFile.Refresh();
            if (bacpacFile.Exists)
                bacpacFile.Delete();

            var command = _fileName + string.Format(_exportSwitchesFormat, bacpacFile.FullName, connectionString);

            CommandPrompt.Run(command);
        }
    }
}
