using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.Domain.Database
{
    using System.Data.SqlClient;

    using SitecoreInstaller.Framework.Diagnostics;

    public class SqlService : ISqlService
    {
        private readonly ILog _log;
        private readonly TSqlService _tSqlService;
        private readonly WebsiteFileTypes _websiteFileTypes;

        public SqlService(ILog log)
        {
            _log = log;
            _tSqlService = new TSqlService();
            _websiteFileTypes = new WebsiteFileTypes();
        }

        public void TestDatabaseSettings(SqlSettings sqlSettings)
        {
            try
            {
                var connectionString = string.Format(_ConnectionStringTestFormat, sqlSettings.InstanceName, sqlSettings.Login, sqlSettings.Password);
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT COUNT(*) FROM sys.all_views", sqlConnection);
                    try
                    {
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                _log.Debug(e.ToString());
                _log.Error(e.Message);
            }
        }

        public void AttachDatabases(FileInfo attachScriptPath, SqlSettings sqlSettings)
        {
            _log.Info("Attaching databases...");
            RunSqlCmd(attachScriptPath, sqlSettings);
            _log.Info("Databases attached");
        }
        public void DetachDatabases(FileInfo detachScriptPath, SqlSettings sqlSettings)
        {
            _log.Info("Detaching databases...");
            RunSqlCmd(detachScriptPath, sqlSettings);
            _log.Info("Databases detached...");
        }
        public void MapDbLogin(FileInfo mapLoginScriptPath, SqlSettings sqlSettings)
        {
            _log.Info("Mapping Sql login '{0}'...", sqlSettings.Login);
            RunSqlCmd(mapLoginScriptPath, sqlSettings);
            _log.Info("Sql login mapped...");
        }

        private void RunSqlCmd(FileInfo sqlScript, SqlSettings sqlSettings)
        {
            var sqlCommander = new SqlCommander(_log);

            if (sqlScript.Exists == false)
            {
                _log.Error("Script not found at: {0}. No logins mapped.", sqlScript.FullName);
                return;
            }


            sqlCommander.ExecuteTSqlScript(sqlScript, sqlSettings.InstanceName);
        }

        public void CreateSqlScripts(SqlSettings sqlSettings, string projectName, DirectoryInfo projectfolder, DirectoryInfo databaseFolder)
        {
            _log.Info("Creating Sql scripts...");

            var attachScript = _tSqlService.GetAttachScript(projectName, GetPhysicalDatabaseNames(databaseFolder), databaseFolder.FullName);
            attachScript.WriteToDisk(AttachScriptTarget(projectName, projectfolder));

            var detachScript = _tSqlService.GetDetachScript(projectName, GetPhysicalDatabaseNames(databaseFolder));
            detachScript.WriteToDisk(DetachScriptTarget(projectName, projectfolder));

            var mapLoginScript = _tSqlService.GetMapLoginScript(projectName, sqlSettings.Login, GetPhysicalDatabaseNames(databaseFolder));
            mapLoginScript.WriteToDisk(MapLoginScriptTarget(projectName, projectfolder));

            _log.Info("Sql scripts created");
        }

        public string GenerateConnectionStringsDelta(SqlSettings sqlSettings, DirectoryInfo databaseFolder, string projectName, IEnumerable<string> existingConnectionStrings)
        {
            _log.Info("Generating connection string delta...");
            var databaseNames = GetPhysicalDatabaseNames(databaseFolder);
            var connectionStringNames = GetConnectionStringNames(databaseNames);
            var connectionStringEntries = string.Empty;
            foreach (var connectionStringName in connectionStringNames)
            {
                var connectionStringEntry = new ConnectionStringEntry(sqlSettings, connectionStringName, projectName);
                if (existingConnectionStrings.ContainsCaseInsensitive(connectionStringName))
                    connectionStringEntries += connectionStringEntry.ToReplaceString();
                else
                    connectionStringEntries += connectionStringEntry.ToInsertString();
            }

            var connectionStringDelta = string.Format(_ConnectionStringDeltaFormat, connectionStringEntries);
            _log.Debug(connectionStringDelta);
            return connectionStringDelta;
        }

        public IEnumerable<string> GetConnectionStringNames(IEnumerable<string> databaseNames)
        {
            if (databaseNames == null)
                return Enumerable.Empty<string>();

            var result = new List<string>();
            foreach (var databaseName in databaseNames)
            {
                var logicalDatabaseName = _tSqlService.GetLogicalDatabaseName(databaseName);

                if (string.IsNullOrEmpty(logicalDatabaseName))
                    continue;
                result.Add(logicalDatabaseName);
            }
            return result.AsUniqueStrings();
        }

        private IEnumerable<string> GetPhysicalDatabaseNames(DirectoryInfo databaseFolder)
        {
            if (Directory.Exists(databaseFolder.FullName) == false)
                return Enumerable.Empty<string>();

            var databaseNames = from databaseName in _websiteFileTypes.DatabaseDataFile.GetFiles(databaseFolder, SearchOption.AllDirectories)
                                select databaseName.NameWithoutExtension();
            return databaseNames.AsUniqueStrings();
        }

        private FileInfo AttachScriptTarget(string projectName, DirectoryInfo projectFolder)
        {
            return GetScriptPath(SqlConstants.AttachScriptName, projectName, projectFolder);
        }

        private FileInfo MapLoginScriptTarget(string projectName, DirectoryInfo projectFolder)
        {
            return GetScriptPath(SqlConstants.MapLoginScriptName, projectName, projectFolder);
        }

        private FileInfo DetachScriptTarget(string projectName, DirectoryInfo projectFolder)
        {
            return GetScriptPath(SqlConstants.DetachScriptName, projectName, projectFolder);
        }

        private FileInfo GetScriptPath(string scriptFileName, string projectName, DirectoryInfo projectFolder)
        {
            return new FileInfo(Path.Combine(projectFolder.FullName, projectName + scriptFileName));
        }
        private const string _ConnectionStringTestFormat = @"Data Source={0};Initial Catalog=Master;User Id={1};Password={2};Connect Timeout=5";
        private const string _ConnectionStringDeltaFormat = @"<?xml version=""1.0""?>
<!-- For more information on using web.config transformation visit http://go.microsoft.com/fwlink/?LinkId=125889 -->
<connectionStrings xmlns:xdt=""http://schemas.microsoft.com/XML-Document-Transform"">
{0}
</connectionStrings>";
    }
}
