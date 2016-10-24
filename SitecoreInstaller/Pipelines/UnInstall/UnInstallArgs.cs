using System.Collections.Generic;
using Newtonsoft.Json;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallArgs : SitecoreInstallerEventArgs
    {
        public bool WasDeleted { get; set; }
        [JsonIgnore]
        public IReadOnlyCollection<DbConnectionString> ConnectionStrings { get; set; }
    }
}
