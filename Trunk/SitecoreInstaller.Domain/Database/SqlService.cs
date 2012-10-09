using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.Domain.Database
{
    using System.Data.SqlClient;

    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    using SitecoreInstaller.Framework.Diagnostics;

    public class SqlService : ISqlService
    {
        private readonly FileTypes _fileTypes;

        public SqlService()
        {
            _fileTypes = new FileTypes();
        }

        public string GenerateConnectionStringsDelta(SqlSettings sqlSettings, IEnumerable<ConnectionStringName> connectionStringNames, IEnumerable<ConnectionStringName> existingConnectionStrings)
        {
            Log.As.Info("Generating connection string delta...");

            var connectionStringEntries = string.Empty;
            foreach (var connectionStringName in connectionStringNames)
            {
                var connectionStringEntry = new ConnectionStringEntry(sqlSettings, connectionStringName);

                if (existingConnectionStrings.Select(name => name.DatabasePart).ContainsCaseInsensitive(connectionStringName.DatabasePart))
                    connectionStringEntries += connectionStringEntry.ToReplaceString();
                else
                    connectionStringEntries += connectionStringEntry.ToInsertString();
            }

            var connectionStringDelta = string.Format(ConnectionStringFormats.ConnectionStringDotConfigDelta, connectionStringEntries);
            Log.As.Debug(connectionStringDelta);
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
            var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString)));
            foreach (Database database in sqlServer.Databases)
            {
                yield return database.Name;
            }
        }

        private IEnumerable<string> GetPhysicalDatabaseNames(DirectoryInfo databaseFolder)
        {
            if (Directory.Exists(databaseFolder.FullName) == false)
                return Enumerable.Empty<string>();

            var databaseNames = from databaseName in _fileTypes.DatabaseDataFile.GetFiles(databaseFolder, SearchOption.AllDirectories)
                                select databaseName.NameWithoutExtension();
            return databaseNames.AsUniqueStrings();
        }
    }
}
