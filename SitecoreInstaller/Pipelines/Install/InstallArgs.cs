using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallArgs : SitecoreInstallerEventArgs
    {
        [JsonIgnore]
        public IReadOnlyCollection<DbConnectionString> ConnectionStrings { get; set; }
        [JsonIgnore]
        public IReadOnlyCollection<SqlDatabaseFilePair> SqlDatabaseFiles { get; set; }
    }
}
