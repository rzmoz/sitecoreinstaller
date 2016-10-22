using System.Collections.Generic;
using System.Data.SqlClient;
using DotNet.Basics.Sys;

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

        protected override IEnumerable<string> AssertWindowsServiceName()
        {
            var lookingFor = TrySetSqlWindowsServiceName("MSSQLSERVER");
            if (WindowsServiceName == null)
                lookingFor += "|" + TrySetSqlWindowsServiceName("SQLEXPRESS");

            if (WindowsServiceName == null)
                yield return $"Sql Server Windows Service not found. Was looking for {lookingFor}";
        }

        protected override IEnumerable<string> AssertInstanceName()
        {
            if (ConnectionEstablished("."))
                InstanceName = ".";
            else if (ConnectionEstablished(@".\SQLEXPRESS"))
                InstanceName = @".\SQLEXPRESS";
            else
                yield return @"Failed to connect to Sql Server. Tried . and .\SQLEXPRESS";
        }

        private string TrySetSqlWindowsServiceName(string serviceName)
        {
            if (WindowsServices.Exists(serviceName))
                WindowsServiceName = serviceName;
            return serviceName;
        }
    }
}
