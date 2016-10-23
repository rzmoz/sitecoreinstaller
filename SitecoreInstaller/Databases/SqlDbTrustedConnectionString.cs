using System.Data.SqlClient;

namespace SitecoreInstaller.Databases
{
    public class SqlDbTrustedConnectionString : SqlDbConnectionString
    {
        public SqlDbTrustedConnectionString(string name, string databaseName, string serverName) : base(name, new SqlConnectionStringBuilder
        {
            ConnectTimeout = 5,
            InitialCatalog = serverName,
            DataSource = databaseName,
            IntegratedSecurity = true
        })
        { }
    }
}
