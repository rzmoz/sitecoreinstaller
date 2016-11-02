using Newtonsoft.Json;

namespace SitecoreInstaller.Pipelines
{
    public class LocalInstallerEventArgs : DeploymentSettings
    {
        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
    }
}
