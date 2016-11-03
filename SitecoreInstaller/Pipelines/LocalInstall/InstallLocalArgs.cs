using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class InstallLocalArgs : LocalArgs
    {
        [JsonIgnore]
        public IReadOnlyCollection<DbConnectionString> ConnectionStrings { get; set; }
        [JsonIgnore]
        public IReadOnlyCollection<SqlDatabaseFilePair> SqlDatabaseFiles { get; set; }
    }
}
