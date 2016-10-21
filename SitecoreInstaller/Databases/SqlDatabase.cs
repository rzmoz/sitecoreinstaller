using System.Collections.Specialized;
using System.Data.SqlClient;
using DotNet.Basics.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using NLog;

namespace SitecoreInstaller.Databases
{
    public class SqlDatabase
    {
        private readonly char[] _physicalDatabaseNameDelimiter = { '.', '_' };
        private readonly ILogger _logger;

        public SqlDatabase(DirPath folder, string physicalDatabaseName, string projectName)
        {
            DataFilePath = folder.ToFile(physicalDatabaseName + FileTypes.SqlMdf.Extension);
            LogFilePath = folder.ToFile(physicalDatabaseName + FileTypes.SqlLdf.Extension);
            PhysicalName = physicalDatabaseName;
            LogicalName = GetLogicalDatabaseName(physicalDatabaseName);
            Name = projectName.Trim() + "_" + LogicalName;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Attach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString.Value)));
                var files = new StringCollection { DataFilePath.FullName, LogFilePath.FullName };

                sqlServer.AttachDatabase(Name, files);

                sqlServer.Databases[Name].SetOwner(sqlSettings.Login, true);

                _logger.Debug($"Sql database {Name} attached");
            }
            catch (SqlServerManagementException ex)
            {
                _logger.Error(ex);
            }
        }

        public void Detach(SqlSettings sqlSettings)
        {
            try
            {
                var sqlServer = new Server(new ServerConnection(new SqlConnection(sqlSettings.ConnectionString.Value)));
                sqlServer.KillAllProcesses(Name);
                sqlServer.DetachDatabase(Name, false);
                _logger.Debug($"Sql database {Name} detached");
            }
            catch (SqlServerManagementException ex)
            {
                _logger.Error(ex);
            }
        }

        public string Name { get; }
        public FilePath DataFilePath { get; }
        public FilePath LogFilePath { get; }
        public string PhysicalName { get; private set; }
        public string LogicalName { get; }

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
                physicalName = physicalName.Replace("sitecore" + delimiter, "");
                physicalName = physicalName.Replace(delimiter, '_');
            }
            return physicalName;
        }
    }
}
