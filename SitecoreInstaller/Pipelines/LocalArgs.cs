using Newtonsoft.Json;

namespace SitecoreInstaller.Pipelines
{
    public class LocalArgs
    {
        public LocalArgs()
        {
            Info = new DeploymentInfo();
        }

        public DeploymentInfo Info { get; set; }

        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
    }
}
