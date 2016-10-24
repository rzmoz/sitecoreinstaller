using System;

namespace SitecoreInstaller
{
    public class DeploymentSettings : EventArgs
    {
        public string Name { get; set; }
        public string Sitecore { get; set; }
        public string License { get; set; }
        public string[] Modules { get; set; }
    }
}
