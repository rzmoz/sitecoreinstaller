using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Domain.Database
{
    using System.Data.SqlClient;

    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    using Framework.Diagnostics;

    public class SqlService
    {
        public string GenerateConnectionStringsDelta(SqlSettings sqlSettings, IEnumerable<ConnectionStringName> databaseNames, IEnumerable<ConnectionStringEntry> existingEntries)
        {
            Log.This.Info("Generating connection string delta...");
            var existingConnectionStringNames = existingEntries.Select(entry => entry.Name).ToList();

            var connectionStringEntries = string.Empty;
            foreach (var databaseName in databaseNames)
            {
                var connectionStringEntry = new ConnectionStringEntry(sqlSettings, databaseName);

                if (existingConnectionStringNames.Select(name => name.DatabasePart).ContainsCaseInsensitive(databaseName.DatabasePart))
                    connectionStringEntries += connectionStringEntry.ToReplaceString();
                else
                    connectionStringEntries += connectionStringEntry.ToInsertString();
            }

            var connectionStringDelta = string.Format(ConnectionStringFormats.ConnectionStringDotConfigDelta, connectionStringEntries);
            Log.This.Debug(connectionStringDelta);
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

        public IEnumerable<string> GetExistingDatabaseNames(SqlSettings sqlSettings)
        {
            var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString.Value)));
            foreach (Database database in sqlServer.Databases)
            {
                yield return database.Name;
            }
        }

        private IEnumerable<string> GetPhysicalDatabaseNames(DirectoryInfo databaseFolder)
        {
            if (Directory.Exists(databaseFolder.FullName) == false)
                return Enumerable.Empty<string>();

            var databaseNames = from databaseName in FileTypes.DatabaseDataFile.GetFiles(databaseFolder, SearchOption.AllDirectories)
                                select databaseName.NameWithoutExtension();
            return databaseNames.AsUniqueStrings();
        }
    }
}
