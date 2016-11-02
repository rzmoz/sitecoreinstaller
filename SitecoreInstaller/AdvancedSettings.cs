using DotNet.Basics.Sys;

namespace SitecoreInstaller
{
    public class AdvancedSettings
    {
        public AdvancedSettings()
        {
            SitesRootDir = @"c:\inetpub\SiRoot\";
            BuildLibraryRootDir = @"c:\SiBuildLibrary\";
            DeploymentUrlSuffix = ".si.local";
        }

        public string SitesRootDir { get; set; }
        public string BuildLibraryRootDir { get; set; }
        public string DeploymentUrlSuffix { get; set; }
        public string GetDeploymentUrl(string name) => name.ToLowerInvariant().EnsureSuffix(DeploymentUrlSuffix);
    }
}
