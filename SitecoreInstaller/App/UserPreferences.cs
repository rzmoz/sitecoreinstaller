using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.App
{
    public class UserPreferences
    {
        public UserPreferences()
        {
            InstallerTargetRootDir = @"c:\inetpub\wwwroot\sitecoreinstaller".ToDir();
            BuildLibraryDir = @"c:\BuildLibrary".ToDir();
            UrlSuffix = @".sc.rar";

            SqlInstanceName = @".\sqlexpress";
            SqlLogin = "sc";
            SqlPassword = "1234";

            MongoEndpoint = "localhost";
            MongoPortNo = "27017";
        }

        public DirectoryInfo InstallerTargetRootDir { get; }
        public DirectoryInfo BuildLibraryDir { get; }
        public string UrlSuffix { get; }

        public string SqlInstanceName { get; }
        public string SqlLogin { get; }
        public string SqlPassword { get; }

        public string MongoEndpoint { get; }
        public string MongoPortNo { get; }
    }
}
