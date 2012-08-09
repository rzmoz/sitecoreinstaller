using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Archiving
{
    using SitecoreInstaller.Framework.IO;
    using SitecoreInstaller.Framework.System;

    using global::System.Diagnostics.Contracts;
    using global::System.IO;

    public class SevenZipFile : CommandPrompt
    {
        private const string _FileName = @"7za.exe";
        private const string _ExtractFormat = _FileName + @" x ""{0}"" ""-o{1}"" -r -y";
        private readonly FileInfo _file;

        public SevenZipFile(FileInfo zipFile)
        {
            Contract.Requires<ArgumentNullException>(zipFile != null);
            Contract.Requires<ArgumentException>(File.Exists(zipFile.FullName));
            _file = zipFile;
        }

        public void ExtractAll(DirectoryInfo target)
        {
            Contract.Requires<ArgumentNullException>(target != null);

            target.CreateIfNotExists();

            var command = string.Format(_ExtractFormat, _file.FullName, target.FullName);
            Run(command);
        }
    }
}
