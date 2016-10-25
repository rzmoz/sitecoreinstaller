namespace SitecoreInstaller
{
    public class BasicSettings
    {
        public BasicSettings()
        {
            SqlLogin = "sa";
            SqlPassword = "1234";
            SqlInstanceName = ".";
            SqlWindowsServiceName = "MSSQLSERVER";

            MongoHost = "localhost:27017";
            MongoWindowsServiceName = "mongoDB";
        }

        public string SqlLogin { get; set; }
        public string SqlPassword { get; set; }
        public string SqlInstanceName { get; set; }
        public string SqlWindowsServiceName { get; set; }

        public string MongoHost { get; set; }
        public string MongoWindowsServiceName { get; set; }
    }
}
