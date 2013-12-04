using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Domain.Database
{
    using System.Collections.Specialized;
    using System.Data.SqlClient;
    using System.IO;

    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    using Framework.Diagnostics;
    using Framework.IO;

    public class SqlDatabase
    {
        private readonly char[] _physicalDatabaseNameDelimiter = { '.', '_' };

        public SqlDatabase(DirectoryInfo folder, string physicalDatabaseName, string projectName)
        {
            DatafileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + FileTypes.DatabaseDataFile.Extension;
            LogFileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + FileTypes.DatabaseLogFile.Extension;
            PhysicalName = physicalDatabaseName;
            LogicalName = GetLogicalDatabaseName(physicalDatabaseName);
            Name = projectName.Trim() + "_" + LogicalName;
        }

        public void Attach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString.Value)));
                var files = new StringCollection { DatafileFullPath, LogFileFullPath };

                sqlServer.AttachDatabase(Name, files);

                sqlServer.Databases[Name].SetOwner(sqlSettings.Login, true);

                Log.This.Info("Database {0} attached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                Log.This.Error(ex.Message);
                Log.This.Debug(ex.ToString());
            }
        }

        public void Detach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString.Value)));
                sqlServer.KillAllProcesses(Name);
                sqlServer.DetachDatabase(Name, false);
                Log.This.Info("Database {0} detached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                Log.This.Error(ex.Message);
                Log.This.Debug(ex.ToString());
            }
        }

        public string Name { get; private set; }
        public string DatafileFullPath { get; private set; }
        public string LogFileFullPath { get; private set; }
        public string PhysicalName { get; private set; }
        public string LogicalName { get; private set; }

        private string GetLogicalDatabaseName(string physicalName)
        {
            int dbPrefixIndex = -1;
            foreach (var dbNameDelimiter in _physicalDatabaseNameDelimiter)
            {
                dbPrefixIndex = physicalName.IndexOf(dbNameDelimiter);
                if (dbPrefixIndex > -1)
                    break;
            }
            if (dbPrefixIndex > -1)
                physicalName = physicalName.Remove(0, dbPrefixIndex + 1);//remove first part of name
            return CleanForSitecoreName(physicalName);//remove any sitecore words from the rest of the name
        }

        private string CleanForSitecoreName(string physicalName)
        {
            foreach (var delimiter in _physicalDatabaseNameDelimiter)
            {
                physicalName = physicalName.Remove("sitecore" + delimiter);
                physicalName = physicalName.Replace(delimiter, '_');
            }
            return physicalName;
        }
    }
}
