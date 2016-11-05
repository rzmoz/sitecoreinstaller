using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreInstaller
{
    public class DeploymentTask
    {
        public DeploymentTask()
        {
            Name = string.Empty;
            Status = DeploymentStatus.Unknown;
        }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DeploymentStatus Status { get; set; }
    }
}
