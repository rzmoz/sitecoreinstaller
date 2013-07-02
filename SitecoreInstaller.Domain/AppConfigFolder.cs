using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain
{
    using System.IO;

    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Framework.IO;

    public class AppConfigFolder : Folder
    {
        private const string _IncludeFolderName = "Include";
        private const string _ConnectionStringsConfigFileName = "ConnectionStrings.config";
        public AppConfigFolder(DirectoryInfo directory)
            : base(directory)
        {
            Include = new IncludeFolder(Directory.CombineTo<DirectoryInfo>(_IncludeFolderName));
            ConnectionStringsConfigFile = new ConnectionStringsFile(Directory.CombineTo<FileInfo>(_ConnectionStringsConfigFileName));
        }

        public IncludeFolder Include { get; private set; }
        public ConnectionStringsFile ConnectionStringsConfigFile { get; private set; }
    }
}
