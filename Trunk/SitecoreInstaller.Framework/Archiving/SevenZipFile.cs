using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Archiving
{
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.IO;
    using SitecoreInstaller.Framework.System;

    using global::System.Diagnostics.Contracts;
    using global::System.IO;

    public class SevenZipFile : CommandPrompt
    {
        private const string _FileName = @"7za.exe";
        private const string _ExtractSwitch = @" x ""{0}"" ""-o{1}"" -y -r";
        private const string _ArchiveSwitch = @" a -tzip ""{0}"" ""{1}\*.*"" -y -r";

        private const string _RunFormat = @" ";

        public FileInfo File { get; private set; }

        public SevenZipFile(FileInfo zipFile)
        {
            Contract.Requires<ArgumentNullException>(zipFile != null);

            File = zipFile;
        }

        public void ExtractAll(DirectoryInfo target)
        {
            Contract.Requires<ArgumentNullException>(target != null);
            if (global::System.IO.File.Exists(File.FullName) == false)
            {
                Log.As.Error("File not found for extrating: {0}", File.FullName);
                return;
            }

            target.CreateIfNotExists();

            var command = string.Format(_FileName + _ExtractSwitch + _RunFormat, File.FullName, target.FullName);
            Run(command);
        }

        public void ZipContent(DirectoryInfo folder)
        {
            var fileName = File.Name;
            if (fileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) == false)
                fileName += ".zip";

            var target = folder.CombineTo<DirectoryInfo>(fileName);
            var command = string.Format(_FileName + _ArchiveSwitch + _RunFormat, target.FullName, folder.FullName);
            Run(command);
        }
    }
}
