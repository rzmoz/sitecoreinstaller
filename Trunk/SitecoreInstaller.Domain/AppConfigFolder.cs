using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain
{
    using System.IO;

    using SitecoreInstaller.Framework.IO;

    public class AppConfigFolder : Folder
    {
        private const string _IncludeFolderName = "Include";
        public AppConfigFolder(DirectoryInfo directory)
            : base(directory)
        {
            Include = Directory.CombineTo<DirectoryInfo>(_IncludeFolderName);
        }

        public DirectoryInfo Include { get; private set; }
    }
}
