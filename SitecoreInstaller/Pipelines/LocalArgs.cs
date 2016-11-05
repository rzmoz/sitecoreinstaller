using Newtonsoft.Json;

namespace SitecoreInstaller.Pipelines
{
    public class LocalArgs
    {
        public LocalArgs()
        {
            Info = new DeploymentInfo { Task = { Status = DeploymentStatus.Unknown } };
        }

        public DeploymentInfo Info { get; set; }

        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
    }
}
