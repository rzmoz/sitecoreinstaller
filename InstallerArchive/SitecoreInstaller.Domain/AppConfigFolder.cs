using System.IO;
using CSharp.Basics.IO;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain
{
    public class AppConfigFolder : Folder
    {
        private const string _includeFolderName = "Include";
        private const string _connectionStringsConfigFileName = "ConnectionStrings.config";
        public AppConfigFolder(DirectoryInfo directory)
            : base(directory)
        {
            Include = new IncludeFolder(Directory.CombineTo<DirectoryInfo>(_includeFolderName));
            ConnectionStringsConfigFile = new ConnectionStringsFile(Directory.CombineTo<FileInfo>(_connectionStringsConfigFileName));
        }

        public IncludeFolder Include { get; private set; }
        public ConnectionStringsFile ConnectionStringsConfigFile { get; private set; }
    }
}
