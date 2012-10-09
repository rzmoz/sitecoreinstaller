using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.Database
{
    public interface ISqlService
    {
        string GenerateConnectionStringsDelta(SqlSettings sqlSettings, string projectName,IEnumerable<string> connectionStringNames, IEnumerable<string> existingConnectionStrings);

        IEnumerable<SqlDatabase> GetDatabases(DirectoryInfo databaseFolder, string projectName);
        IEnumerable<string> GetExistingDatabaseNames(SqlSettings sqlSettings);
    }
}
