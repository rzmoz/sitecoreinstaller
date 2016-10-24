using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallEventArgs : DeploymentSettings
    {
        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
        [JsonIgnore]
        public IReadOnlyCollection<DbConnectionString> ConnectionStrings { get; set; }
        [JsonIgnore]
        public IReadOnlyCollection<SqlDatabaseFilePair> SqlDatabaseFiles { get; set; }
    }
}
