namespace SitecoreInstaller.App
{
    public class UserPreferences
    {
        public UserPreferences()
        {
            InstallerTargetRootDir = @"c:\inetpub\wwwroot";
            BuildLibraryDir = @"c:\BuildLibrary";
            UrlSuffix = @".sc.rar";

            SqlInstanceName = @"lt-rar2";
            SqlLogin = "sc";
            SqlPassword = "1234";

            MongoEndpoint = "localhost";
            MongoPortNo = "27017";
        }

        public string InstallerTargetRootDir { get; }
        public string BuildLibraryDir { get; }
        public string UrlSuffix { get; }

        public string SqlInstanceName { get; }
        public string SqlLogin { get; }
        public string SqlPassword { get; }

        public string MongoEndpoint { get; }
        public string MongoPortNo { get; }
    }
}
