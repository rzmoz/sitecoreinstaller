using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.Domain.Database
{
    using System.Data.SqlClient;

    using SitecoreInstaller.Framework.Diagnostics;

    public class SqlService : ISqlService
    {
        private readonly ILog _log;

        public SqlService(ILog log)
        {
            _log = log;
            Databases = new DatabaseRepository(_log);
        }

        public void TestDatabaseSettings(SqlSettings sqlSettings)
        {
            try
            {
                var connectionString = sqlSettings.ConnectionString + ";Connect Timeout=5";
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT COUNT(*) FROM sys.all_views", sqlConnection);
                    try
                    {
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                _log.Error(e.Message);
            }
        }

        public string GenerateConnectionStringsDelta(SqlSettings sqlSettings, DirectoryInfo databaseFolder, string projectName, IEnumerable<string> existingConnectionStrings)
        {
            _log.Info("Generating connection string delta...");
            var databases =  Databases.Get(databaseFolder, projectName);
            var connectionStringNames = databases.Select(db => db.LogicalName).AsUniqueStrings();
            var connectionStringEntries = string.Empty;
            foreach (var connectionStringName in connectionStringNames)
            {
                var connectionStringEntry = new ConnectionStringEntry(sqlSettings, connectionStringName, projectName);
                if (existingConnectionStrings.ContainsCaseInsensitive(connectionStringName))
                    connectionStringEntries += connectionStringEntry.ToReplaceString();
                else
                    connectionStringEntries += connectionStringEntry.ToInsertString();
            }

            var connectionStringDelta = string.Format(ConnectionStringFormats.ConnectionStringDotConfigDelta, connectionStringEntries);
            _log.Debug(connectionStringDelta);
            return connectionStringDelta;
          
        }

        public IDatabaseRepository Databases { get; private set; }
    }
}
