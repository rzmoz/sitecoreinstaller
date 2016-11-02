using Newtonsoft.Json;

namespace SitecoreInstaller.Pipelines
{
    public class LocalInstallerEventArgs
    {
        public LocalInstallerEventArgs()
        {
            Info = new DeploymentInfo();
        }

        public DeploymentInfo Info { get; set; }

        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
    }
}
