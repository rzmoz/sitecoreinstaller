using Newtonsoft.Json;

namespace SitecoreInstaller.Pipelines
{
    public class SitecoreInstallerEventArgs : DeploymentSettings
    {
        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
    }
}
