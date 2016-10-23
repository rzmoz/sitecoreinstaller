using Newtonsoft.Json;

namespace SitecoreInstaller
{
    public class DeploymentSettings
    {
        public string Name { get; set; }
        public string Sitecore { get; set; }
        public string License { get; set; }
        public string[] Modules { get; set; }
        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
    }
}
