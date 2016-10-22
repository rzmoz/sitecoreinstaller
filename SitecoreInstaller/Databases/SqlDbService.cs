using System.Collections.Generic;
using System.Data.SqlClient;

namespace SitecoreInstaller.Databases
{
    public class SqlDbService : DbService
    {
        private const string _trustedServerConStrFormat = "Server={0};Trusted_Connection=True;Connection Timeout=5;";

        public SqlConnection Connection(string databaseName) => new SqlConnection(new SqlDbTrustedConnectionString(databaseName, InstanceName).Value);

        protected override bool ConnectionEstablished(string instanceName)
        {
            var connectionString = string.Format(_trustedServerConStrFormat, instanceName);
            using (var connection = new SqlConnection(connectionString))
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
        }

        protected override IEnumerable<string> GetWindowsServiceNameCandidates()
        {
            yield return "MSSQLSERVER";
            yield return "SQLEXPRESS";
        }

        protected override IEnumerable<string> GetInstanceNameCandidates()
        {
            yield return ".";
            yield return @".\SQLEXPRESS";
        }
    }
}
