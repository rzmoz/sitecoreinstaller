using DotNet.Basics.Sys;
using Newtonsoft.Json;

namespace SitecoreInstaller.Pipelines
{
    public class SitecoreInstallerEventArgs : DeploymentSettings
    {
        [JsonIgnore]
        public DeploymentDir DeploymentDir { get; set; }
        //TODO:Get url suffix from user settings
        public string DeploymentUrl => Name.EnsureSuffix(".si.local");
    }
}
