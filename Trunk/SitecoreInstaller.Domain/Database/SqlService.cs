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
        private readonly WebsiteFileTypes _websiteFileTypes;

        public SqlService()
        {
            _websiteFileTypes = new WebsiteFileTypes();
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
                Log.ItAs.Debug(e.ToString());
                Log.ItAs.Error(e.Message);
            }
        }

        public string GenerateConnectionStringsDelta(SqlSettings sqlSettings, DirectoryInfo databaseFolder, string projectName, IEnumerable<string> existingConnectionStrings)
        {
            Log.ItAs.Info("Generating connection string delta...");
            var databases =  GetDatabases(databaseFolder, projectName);
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
            Log.ItAs.Debug(connectionStringDelta);
            return connectionStringDelta;
        }

        public IEnumerable<SqlDatabase> GetDatabases(DirectoryInfo databaseFolder, string projectName)
        {
            var databaseNames = GetPhysicalDatabaseNames(databaseFolder);

            foreach (var databaseName in databaseNames)
            {
                yield return new SqlDatabase(databaseFolder, databaseName, projectName);
            }
        }

        private IEnumerable<string> GetPhysicalDatabaseNames(DirectoryInfo databaseFolder)
        {
            if (Directory.Exists(databaseFolder.FullName) == false)
                return Enumerable.Empty<string>();

            var databaseNames = from databaseName in _websiteFileTypes.DatabaseDataFile.GetFiles(databaseFolder, SearchOption.AllDirectories)
                                select databaseName.NameWithoutExtension();
            return databaseNames.AsUniqueStrings();
        }
    }
}
