using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.Database
{
    public interface ISqlService
    {
        void TestDatabaseSettings(SqlSettings sqlSettings);

        void AttachDatabases(FileInfo attachScriptPath, SqlSettings sqlSettings);

        void DetachDatabases(FileInfo detachScriptPath, SqlSettings sqlSettings);

        void MapDbLogin(FileInfo mapLoginScriptPath, SqlSettings sqlSettings);

        void CreateSqlScripts(SqlSettings sqlSettings, string projectName, DirectoryInfo projectfolder, DirectoryInfo databaseFolder);

        string GenerateConnectionStringsDelta(SqlSettings sqlSettings, DirectoryInfo databaseFolder, string projectName, IEnumerable<string> existingConnectionStrings);
    }
}
