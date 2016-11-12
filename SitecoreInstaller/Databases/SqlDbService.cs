using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using DotNet.Basics.NLog;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SitecoreInstaller.Databases
{
    public class SqlDbService : DbService
    {
        private const string _trustedServerConStrFormat = "Server={0};Trusted_Connection=True;Connection Timeout=5;";

        private readonly BasicSettings _basicSettings;

        public SqlDbService(BasicSettings basicSettings)
        {
            if (basicSettings == null) throw new ArgumentNullException(nameof(basicSettings));
            _basicSettings = basicSettings;
        }

        public void AttacSqlhDatabases(IEnumerable<SqlDatabaseFilePair> sqlDatabaseFilePairs)
        {
            var connectionString = string.Format(_trustedServerConStrFormat, InstanceName);
            var sqlServer = new Server(new ServerConnection(new SqlConnection(connectionString)));

            foreach (var sqlDbFilePair in sqlDatabaseFilePairs)
            {
                try
                {
                    this.NLog().Debug($"Attaching {sqlDbFilePair.DataFile.FullName}");
                    var files = new StringCollection { sqlDbFilePair.DataFile.FullName, sqlDbFilePair.LogFile.FullName };
                    sqlServer.AttachDatabase(sqlDbFilePair.Name.FullName, files);
                    this.NLog().Trace($"Atached {sqlDbFilePair.DataFile.FullName}");
                }
                catch (Exception e)
                {
                    this.NLog().Error($"Attaching {sqlDbFilePair.DataFile.FullName} failed: {e}");
                }
            }
        }

        public void DetachDatabases(IEnumerable<SqlDbConnectionString> sqlDbConnectionStrings)
        {
            var connectionString = string.Format(_trustedServerConStrFormat, InstanceName);
            var sqlServer = new Server(new ServerConnection(new SqlConnection(connectionString)));

            WorkOnConnectionStrings(() => sqlDbConnectionStrings, conStr =>
              {
                  sqlServer.KillAllProcesses(conStr.DatabaseName);
                  sqlServer.DetachDatabase(conStr.DatabaseName, false);
              }, "detaching", "detached");
        }

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
            yield return _basicSettings.SqlWindowsServiceName;//defaults to "MSSQLSERVER" unless overridden by user
            yield return "SQLEXPRESS";
        }

        protected override IEnumerable<string> GetInstanceNameCandidates()
        {
            yield return _basicSettings.SqlInstanceName;//defaults to "." unless overridden by user
            yield return @".\SQLEXPRESS";
        }

        protected override void CustomAssert(List<string> issues)
        {
            //ensure mixed login Mode
            var sqlServer = GetTrustedServer(InstanceName);
            if (sqlServer.Settings.LoginMode != ServerLoginMode.Mixed)
            {
                this.NLog().Debug($"Setting Mixed mode loging for Sql Service {WindowsServiceName}");
                sqlServer.Settings.LoginMode = ServerLoginMode.Mixed;
                sqlServer.Alter();
                RestartWindowsService();
            }
            if (sqlServer.Settings.LoginMode == ServerLoginMode.Mixed)
                this.NLog().Trace($"Sql Server Mixed mode is set on {WindowsServiceName}");
            else
                issues.Add($"Setting Sql Server mixed mode failed. Sql database connections will not work");

            EnsureUserIsSysadmin(_basicSettings.SqlLogin, _basicSettings.SqlPassword, issues);
        }

        private void EnsureUserIsSysadmin(string username, string password, List<string> issues)
        {
            var role = "sysadmin";
            try
            {
                var sqlServer = GetTrustedServer(InstanceName);

                var existingUser = sqlServer.Logins[username];
                if (existingUser == null)
                {
                    this.NLog().Debug($"Adding {username} Sql User to {role} role");
                    var login = new Login(sqlServer, password)
                    {
                        PasswordExpirationEnabled = false,
                        PasswordPolicyEnforced = false,
                        LoginType = LoginType.SqlLogin
                    };

                    login.Create(password);
                    login.AddToRole(role);
                    this.NLog().Trace($"{username} Sql User to {role} role added");
                }
                else
                {
                    this.NLog().Debug($"Updating password for {username} Sql User");
                    existingUser.ChangePassword(password);
                    if (username != "sa")//special service principal is already sysadmin
                        existingUser.AddToRole(role);
                    this.NLog().Trace($"Password updated for {username} Sql User");
                }
            }
            catch (Exception e)
            { issues.Add($"Couldn't add user to role: {role}\r\n{e}"); }
        }

        private Server GetTrustedServer(string instanceName)
        {
            return new Server(new ServerConnection(GetTrustedSqlConnection(instanceName)));
        }
        private SqlConnection GetTrustedSqlConnection(string instanceName)
        {
            var connectionString = string.Format(_trustedServerConStrFormat, instanceName);
            return new SqlConnection(connectionString);
        }
    }
}
