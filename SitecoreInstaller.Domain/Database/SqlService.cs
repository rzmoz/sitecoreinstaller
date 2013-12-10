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
        public void EnableMixedAuthenticationMode()
        {
            var sqlServer = GetSqlServerTrustedConnection();
            if (sqlServer.Settings.LoginMode == ServerLoginMode.Mixed)
                return;
            sqlServer.Settings.LoginMode = ServerLoginMode.Mixed;
            sqlServer.Alter();
        }

        private static Server GetSqlServerTrustedConnection()
        {
            var sqlServer = new Server(new ServerConnection(new SqlConnection("Server=.;Trusted_Connection=True;")));
            return sqlServer;
        }

        public void AddUserAsSysadmin(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = GetSqlServerTrustedConnection();

                var existingUser = sqlServer.Logins[sqlSettings.Login];
                if (existingUser != null)
                    existingUser.Drop();

                var login = new Login(sqlServer, sqlSettings.Login)
                {
                    PasswordExpirationEnabled = false,
                    PasswordPolicyEnforced = false,
                    LoginType = LoginType.SqlLogin
                };

                login.Create(sqlSettings.Password);
                login.AddToRole("sysadmin");
            }
            catch (SqlException e)
            {
                Log.ToApp.Warning("Couldn't add user as sysadmin to sql server\r\n{0}", e);
            }
        }


        public string GenerateConnectionStringsDelta(SqlSettings sqlSettings, IEnumerable<ConnectionStringName> databaseNames, IEnumerable<ConnectionStringEntry> existingEntries)
        {
            Log.ToApp.Info("Generating connection string delta...");
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
            Log.ToApp.Debug(connectionStringDelta);
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

            var databaseNames = from databaseName in databaseFolder.GetFiles(FileTypes.DatabaseDataFile, SearchOption.AllDirectories)
                                select databaseName.NameWithoutExtension();
            return databaseNames.AsUniqueStrings();
        }
    }
}
