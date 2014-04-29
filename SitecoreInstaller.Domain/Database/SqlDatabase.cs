using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IOx;
using SitecoreInstaller.Framework.Sys;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;


namespace SitecoreInstaller.Domain.Database
{
    public class SqlDatabase
    {
        private readonly char[] _physicalDatabaseNameDelimiter = { '.', '_' };

        public SqlDatabase(DirectoryInfo folder, string physicalDatabaseName, string projectName)
        {
            DataFileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + FileTypes.SqlMdf.Extension;
            LogFileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + FileTypes.SqlLdf.Extension;
            PhysicalName = physicalDatabaseName;
            LogicalName = GetLogicalDatabaseName(physicalDatabaseName);
            Name = projectName.Trim() + "_" + LogicalName;
        }

        public void Attach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString.Value)));
                var files = new StringCollection { DataFileFullPath, LogFileFullPath };

                sqlServer.AttachDatabase(Name, files);

                sqlServer.Databases[Name].SetOwner(sqlSettings.Login, true);

                Log.ToApp.Info("Database {0} attached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                Log.ToApp.Error(ex.Message);
                Log.ToApp.Debug(ex.ToString());
            }
        }

        public void Detach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString.Value)));
                sqlServer.KillAllProcesses(Name);
                sqlServer.DetachDatabase(Name, false);
                Log.ToApp.Info("Database {0} detached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                Log.ToApp.Error(ex.Message);
                Log.ToApp.Debug(ex.ToString());
            }
        }

        public string Name { get; private set; }
        public string DataFileFullPath { get; private set; }
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
