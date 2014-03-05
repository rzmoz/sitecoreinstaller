using System;
using System.Data.SqlClient;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Framework.Databases;

namespace SitecoreInstaller.Azure.Packaging.Databases
{
    public class SqlServerService
    {
        private readonly SqlServer _sqlServer;

        public SqlServerService()
        {
            _sqlServer = new SqlServer();
        }

        public void PrepDatabaseForBacpac(ConnectionStringEntry entry)
        {
            if (entry == null) throw new ArgumentNullException("entry");
            var connectionString = entry.ConnectionString as MsSqlConnectionString;
            if (connectionString == null)
                return;

            using (var connection = new SqlConnection(connectionString.Value))
            {
                switch (entry.Name.DatabasePart.ToLower())
                {
                    case "core":
                        PrepCoreDatabase(connection);
                        break;
                    case "master":
                        PrepMasterDatabase(connection);
                        break;
                    case "web":
                        PrepWebDatabase(connection);
                        break;
                    case "analytics":
                        PrepAnalyticsDatabase(connection);
                        break;
                }
            }
        }

        private void PrepMasterDatabase(SqlConnection connection)
        {
            _sqlServer.ExecuteNonQuery(DatabasesResources.AddClusteredIndexesSql, connection);
            _sqlServer.ExecuteNonQuery(DatabasesResources.DropExtendedPropertiesSql, connection);
        }

        private void PrepCoreDatabase(SqlConnection connection)
        {
            _sqlServer.ExecuteNonQuery(DatabasesResources.AddClusteredIndexesSql, connection);
            _sqlServer.ExecuteNonQuery(DatabasesResources.AddClusteredIndexesSqlCoreOnly, connection);
            _sqlServer.ExecuteNonQuery(DatabasesResources.DropExtendedPropertiesSql, connection);
            _sqlServer.ExecuteNonQuery(DatabasesResources.AddTableHintOnLocksSql, connection);
        }

        private void PrepWebDatabase(SqlConnection connection)
        {
            _sqlServer.ExecuteNonQuery(DatabasesResources.AddClusteredIndexesSql, connection);
            _sqlServer.ExecuteNonQuery(DatabasesResources.DropExtendedPropertiesSql, connection);
        }

        private void PrepAnalyticsDatabase(SqlConnection connection)
        {
        }
    }
}
