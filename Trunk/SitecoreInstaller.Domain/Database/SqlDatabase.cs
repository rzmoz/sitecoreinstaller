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
        private readonly ILog _log;
        private readonly char[] _physicalDatabaseNameDelimiter = new[] { '.', '_' };
        private readonly WebsiteFileTypes _websiteFileTypes;

        public SqlDatabase(DirectoryInfo folder, string physicalDatabaseName, string projectName, ILog log)
        {
            _log = log;
            _websiteFileTypes = new WebsiteFileTypes();

            DatafileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + _websiteFileTypes.DatabaseDataFile.Extension;
            LogFileFullPath = Path.Combine(folder.FullName, physicalDatabaseName) + _websiteFileTypes.DatabaseLogFile.Extension;
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
                sqlServer.AttachDatabase(Name, files, sqlSettings.Login, AttachOptions.None);
                _log.Info("Database {0} attached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                _log.Error(ex.Message);
                _log.Debug(ex.ToString());
            }
        }

        public void Detach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString)));
                sqlServer.KillDatabase(Name);
                _log.Info("Database {0} detached", Name);
            }
            catch (SqlServerManagementException ex)
            {
                _log.Error(ex.Message);
                _log.Debug(ex.ToString());
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
