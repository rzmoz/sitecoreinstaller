using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{
    public class UnInstallLocalArgs : LocalArgs
    {
        public bool WasDeleted { get; set; }
        [JsonIgnore]
        public IReadOnlyCollection<DbConnectionString> ConnectionStrings { get; set; }
    }
}
