using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Database
{
    using System.Collections.Specialized;
    using System.Data.SqlClient;
    using System.IO;

    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;

    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.IO;

    public class SqlDatabase
    {
        private readonly char[] _physicalDatabaseNameDelimiter = new[] { '.', '_' };
        private readonly ScFileTypes _scFileTypes;

        public SqlDatabase(DirectoryInfo folder, string physicalDatabaseName, string projectName)
        {
            _scFileTypes = new ScFileTypes();

            DatafileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + _scFileTypes.DatabaseDataFile.Extension;
            LogFileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + _scFileTypes.DatabaseLogFile.Extension;
            PhysicalName = physicalDatabaseName;
            LogicalName = GetLogicalDatabaseName(physicalDatabaseName);
            Name = projectName.Trim() + "_" + LogicalName;
        }

        public void Attach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString)));
                var files = new StringCollection { DatafileFullPath, LogFileFullPath };
                
                sqlServer.AttachDatabase(Name,files);
               
                sqlServer.Databases[Name].SetOwner(sqlSettings.Login,true);
                
                Log.As.Info("Database {0} attached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                Log.As.Error(ex.Message);
                Log.As.Debug(ex.ToString());
            }
        }

        public void Detach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString)));
                sqlServer.KillAllProcesses(Name);
                sqlServer.DetachDatabase(Name,false);
                Log.As.Info("Database {0} detached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                Log.As.Error(ex.Message);
                Log.As.Debug(ex.ToString());
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
                dbPrefixIndex = physicalName.LastIndexOf(dbNameDelimiter);
                if (dbPrefixIndex > -1)
                    break;
            }
            if (dbPrefixIndex > -1)
                return physicalName.Remove(0, dbPrefixIndex + 1);
            return physicalName;
        }
    }
}
