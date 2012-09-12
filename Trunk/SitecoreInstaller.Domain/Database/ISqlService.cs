using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.Database
{
    public interface ISqlService
    {
        string GenerateConnectionStringsDelta(SqlSettings sqlSettings, DirectoryInfo databaseFolder, string projectName, IEnumerable<string> existingConnectionStrings);

        IEnumerable<SqlDatabase> GetDatabases(DirectoryInfo databaseFolder, string projectName);
    }
}
