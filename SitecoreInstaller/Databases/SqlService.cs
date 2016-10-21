using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using NLog;

namespace SitecoreInstaller.Databases
{
    public class SqlService
    {
        private readonly ILogger _logger;

        private SqlConnection GetSqlConnection() { return new SqlConnection("Server=.;Trusted_Connection=True;Connection Timeout=5;"); }
        private SqlConnection GetSqlExpresssConnection() { return new SqlConnection(@"Server=.\SQLEXPRESS;Trusted_Connection=True;Connection Timeout=5;"); }

        public Func<SqlConnection> GetTrustedConnection = () => null;

        public SqlService()
        {
            _logger = LogManager.GetLogger(nameof(SqlService));
        }

        public void DetermineSqlConnection()
        {
            if (ConnectionWorks(GetSqlConnection()))
            {
                GetTrustedConnection = GetSqlConnection;
            }
            else if (ConnectionWorks(GetSqlExpresssConnection()))
            {
                GetTrustedConnection = GetSqlExpresssConnection;
            }
            else
            {
                throw new SqlServerManagementException("Couldn't determine sql connection. Looked for default instance . and .\\SQLEXPRESS");
            }
        }

        private bool ConnectionWorks(SqlConnection connection)
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (SqlException) { return false; }
        }

        public void EnableMixedAuthenticationMode()
        {
            var sqlServer = GetSqlServerTrustedConnection();
            if (sqlServer.Settings.LoginMode == ServerLoginMode.Mixed)
                return;
            sqlServer.Settings.LoginMode = ServerLoginMode.Mixed;
            sqlServer.Alter();
            using (var connection = GetTrustedConnection())
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

        public void TryStartSqlService()
        {
            _logger.Debug("Trying to start default Sql Server windows service");
            SqlServerPrompt.StartServer("MSSQLSERVER");
            SqlServerPrompt.StartServer("SQLEXPRESS");
        }

        public void RestartServer(SqlConnection connection)
        {
            const string cmd = "SELECT @@servicename";
            var instanceName = connection.ExecuteScalar(cmd);
            SqlServerPrompt.StopServer(instanceName);
            SqlServerPrompt.StartServer(instanceName);
        }

        private Server GetSqlServerTrustedConnection()
        {
            var sqlServer = new Server(new ServerConnection(GetTrustedConnection()));

            var connectionEstablished = false;
            Repeat.Task(() =>
            {
                try
                {
                    sqlServer.Refresh();
                    connectionEstablished = true;
                }
                catch (FailedOperationException)
                {
                    _logger.Debug("Failed to establish connection to sql database" + sqlServer.ConnectionContext.ConnectionString);
                }

            }).WithOptions(o =>
                {
                    o.MaxTries = 10;
                    o.RetryDelay = 3.Seconds();
                })
            .Until(() => connectionEstablished);

            return sqlServer;
        }

        public void AddUserAsSysadmin(SqlSettings sqlSettings)
        {
            var role = "sysadmin";
            try
            {
                var sqlServer = GetSqlServerTrustedConnection();

                var login = sqlServer.Logins[sqlSettings.Login];
                if (login == null)
                {
                    login = new Login(sqlServer, sqlSettings.Login)
                    {
                        PasswordExpirationEnabled = false,
                        PasswordPolicyEnforced = false,
                        LoginType = LoginType.SqlLogin
                    };
                    login.Create(sqlSettings.Password);
                }
                else
                {
                    login.ChangePassword(sqlSettings.Password);
                }
                login.AddToRole(role);
            }
            catch (FailedOperationException e)
            {
                _logger.Warn($"Couldn't add user as {role} to sql server\r\n{e}");
            }
            catch (SqlException e)
            {
                _logger.Warn($"Couldn't add user as {role} to sql server\r\n{e}");
            }
        }


        public string GenerateConnectionStringsXdt(SqlSettings sqlSettings, IEnumerable<ConnectionStringName> databaseNames, IEnumerable<ConnectionStringEntry> existingEntries)
        {
            _logger.Debug($"Generating connection string xdt...");

            var existingConnectionStringNames = existingEntries.Select(entry => entry.Name).ToList();

            var connectionStringEntries = string.Empty;
            foreach (var databaseName in databaseNames)
            {
                var connectionStringEntry = new ConnectionStringEntry(sqlSettings, databaseName);

                if (existingConnectionStringNames.Select(name => name.DatabasePart).Any(dbp => dbp.Equals(databaseName.DatabasePart, StringComparison.OrdinalIgnoreCase)))
                    connectionStringEntries += connectionStringEntry.ToReplaceString();
                else
                    connectionStringEntries += connectionStringEntry.ToInsertString();
            }

            var connectionStringsXdt = string.Format(ConnectionStringFormats.ConnectionStringXdtFormat, connectionStringEntries);
            _logger.Debug(connectionStringsXdt);
            return connectionStringsXdt;
        }

        public IEnumerable<SqlDatabase> GetDatabases(DirPath databaseFolder, string projectName)
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

        private IEnumerable<string> GetPhysicalDatabaseNames(DirPath databaseFolder)
        {
            if (databaseFolder.Exists())
                return Enumerable.Empty<string>();

            var databaseNames = from databaseName in databaseFolder.GetFiles(FileTypes.SqlMdf.GetAllSearchPattern, true)
                                select databaseName.NameWithoutExtension;
            return databaseNames.AsUniqueStrings();
        }
    }
}
