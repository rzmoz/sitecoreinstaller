using System;
using System.IO;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Archiving
{
    public class SevenZipFile
    {
        private const string _fileName = @"7za.exe";
        private const string _extractSwitch = @" x ""{0}"" ""-o{1}"" -y -r -mmt";
        private const string _archiveSwitch = @" a -tzip ""{0}"" ""{1}\*"" -y -r -mmt";

        private const string _runFormat = @" ";

        public FileInfo File { get; private set; }

        public SevenZipFile(FileInfo zipFile)
        {
            if (zipFile == null) { throw new ArgumentNullException("zipFile"); }

            File = zipFile;
            if (File.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) == false)
                File = new FileInfo(File.FullName + ".zip");
        }

        public void ExtractAll(DirectoryInfo target)
        {
            if (target == null) { throw new ArgumentNullException("target"); }

            File.Refresh();
            if (File.Exists == false)
            {
                Log.ToApp.Error("File not found for extrating: {0}", File.FullName);
                return;
            }

            target.CreateIfNotExists();

            CommandPrompt.Run(_fileName + _extractSwitch + _runFormat, File.FullName, target.FullName);
        }

        public void ZipContent(DirectoryInfo folder)
        {
            var fileName = File.Name;

            var target = folder.CombineTo<DirectoryInfo>(fileName);

            CommandPrompt.Run(_fileName + _archiveSwitch + _runFormat, target.FullName, folder.FullName);
        }
    }
}
