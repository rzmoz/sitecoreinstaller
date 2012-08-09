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

        public SqlService(ILog log)
        {
            _log = log;
            Databases = new DatabaseRepository();
        }

        public void TestDatabaseSettings(SqlSettings sqlSettings)
        {
            try
            {
                var connectionString = sqlSettings.ConnectionString + ";Connect Timeout=5";
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

        public string GenerateConnectionStringsDelta(SqlSettings sqlSettings, DirectoryInfo databaseFolder, string projectName, IEnumerable<string> existingConnectionStrings)
        {
            throw new NotImplementedException();
            /*
            _log.Info("Generating connection string delta...");
            var databaseNames =  GetPhysicalDatabaseNames(databaseFolder);
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
          */
        }

        public IDatabaseRepository Databases { get; private set; }

        public IEnumerable<string> GetConnectionStringNames(IEnumerable<string> databaseNames)
        {
            throw new NotImplementedException();
            /*
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
             * */
        }


        private const string _ConnectionStringDeltaFormat = @"<?xml version=""1.0""?>
<!-- For more information on using web.config transformation visit http://go.microsoft.com/fwlink/?LinkId=125889 -->
<connectionStrings xmlns:xdt=""http://schemas.microsoft.com/XML-Document-Transform"">
{0}
</connectionStrings>";
    }
}
