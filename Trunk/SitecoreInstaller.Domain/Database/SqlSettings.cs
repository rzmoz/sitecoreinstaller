namespace SitecoreInstaller.Domain.Database
{
    public class SqlSettings
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }

        public string ConnectionString
        {
            get
            {
                return string.Format(_ConnectionStringFormat, InstanceName, Login, Password);
            }
        }
        private const string _ConnectionStringFormat = @"Data Source={0};Initial Catalog=Master;User Id={1};Password={2}";
    }
}
