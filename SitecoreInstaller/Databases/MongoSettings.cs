namespace SitecoreInstaller.Databases
{
    public class MongoSettings
    {
        public MongoSettings()
        {
            Username = string.Empty;
            Password = string.Empty;
            Endpoint = "localhost";
            Port = 27017;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Endpoint { get; set; }
        public int Port { get; set; }
    }
}
