using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using DotNet.Basics.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SitecoreInstaller.Databases
{
    public class SqlDbService : DbService
    {
        private const string _trustedServerConStrFormat = "Server={0};Trusted_Connection=True;Connection Timeout=5;";

        public void AttacSqlhDatabases(IEnumerable<SqlDatabaseFilePair> sqlDatabaseFilePairs)
        {
            var connectionString = string.Format(_trustedServerConStrFormat, InstanceName);
            var sqlServer = new Server(new ServerConnection(new SqlConnection(connectionString)));
            
            foreach (var sqlDbFilePair in sqlDatabaseFilePairs)
            {
                try
                {
                    Logger.Debug($"Attaching {sqlDbFilePair.DataFile.FullName}");
                    var files = new StringCollection { sqlDbFilePair.DataFile.FullName, sqlDbFilePair.LogFile.FullName };
                    sqlServer.AttachDatabase(sqlDbFilePair.Name.FullName, files);
                    Logger.Trace($"Atached {sqlDbFilePair.DataFile.FullName}");
                }
                catch (Exception e)
                {
                    Logger.Error($"Attaching {sqlDbFilePair.DataFile.FullName} failed: {e}");
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
            yield return "MSSQLSERVER";
            yield return "SQLEXPRESS";
        }

        protected override IEnumerable<string> GetInstanceNameCandidates()
        {
            //TODO:Get from user settings
            yield return ".";
            yield return @".\SQLEXPRESS";
        }
    }
}
