using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharp.Basics.Sys;
using SitecoreInstaller.Framework.Databases;
using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Sys;
using System.Data.SqlClient;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Database
{
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    

    public class SqlService
    {
        private SqlConnection TrustedConnection
        {
            get { return new SqlConnection("Server=.;Trusted_Connection=True;"); }
        }

        public void EnableMixedAuthenticationMode()
        {
            var sqlServer = GetSqlServerTrustedConnection();
            if (sqlServer.Settings.LoginMode == ServerLoginMode.Mixed)
                return;
            sqlServer.Settings.LoginMode = ServerLoginMode.Mixed;
            sqlServer.Alter();
            using (var connection = TrustedConnection)
                RestartServer(connection);
        }
        public bool IsStarted()
        {
            try
            {
                var sqlServer = GetSqlServerTrustedConnection();
                sqlServer.Refresh();//verify that server is up and running
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void TryStartDefaultSqlService()
        {
            Log.ToApp.Debug("Trying to start default MSSQLSERVER service");
            var msSqlResult = SqlServerPrompt.StartServer("MSSQLSERVER", LogType.Null);
            var sqlExpressResult = SqlServerPrompt.StartServer("SQLEXPRESS", LogType.Null);

            Log.ToApp.Debug(msSqlResult.StandardOutput);
            Log.ToApp.Debug(sqlExpressResult.StandardOutput);

            var logType = LogType.Debug;

            if (msSqlResult.HasErrors && sqlExpressResult.HasErrors)
                logType = LogType.Error;

            Log.ToApp.As(logType, msSqlResult.StandardError);
            Log.ToApp.As(logType, sqlExpressResult.StandardError);
        }

        public void RestartServer(SqlConnection connection)
        {
            const string cmd = "SELECT @@servicename";
            var command = new SqlCommand(cmd, connection);
            command.Connection.Open();
            var instanceName = command.ExecuteScalar().ToString();
            SqlServerPrompt.StopServer(instanceName);
            SqlServerPrompt.StartServer(instanceName);
        }

        private Server GetSqlServerTrustedConnection()
        {
            var sqlServer = new Server(new ServerConnection(TrustedConnection));

            var connectionEstablished = false;
            Do.This(() =>
            {
                try
                {
                    sqlServer.Refresh();
                    connectionEstablished = true;
                }
                catch (FailedOperationException)
                {
                    Log.ToApp.Debug("Failed to establish a connection:" + sqlServer.ConnectionContext.ConnectionString);
                }

            }).Until(() => connectionEstablished, TimeSpan.FromSeconds(10), 10);

            return sqlServer;
        }

        public void AddUserAsSysadmin(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = GetSqlServerTrustedConnection();

                var existingUser = sqlServer.Logins[sqlSettings.Login];
                if (existingUser != null)
                {
                    existingUser.Drop();
                }


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
