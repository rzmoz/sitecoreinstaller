using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.Database
{
    public interface ISqlService
    {
        string GenerateConnectionStringsDelta(SqlSettings sqlSettings, IEnumerable<ConnectionStringName> connectionStringNames, IEnumerable<ConnectionStringName> existingConnectionStrings);

        IEnumerable<SqlDatabase> GetDatabases(DirectoryInfo databaseFolder, string projectName);
        IEnumerable<string> GetExistingDatabaseNames(SqlSettings sqlSettings);
    }
}
