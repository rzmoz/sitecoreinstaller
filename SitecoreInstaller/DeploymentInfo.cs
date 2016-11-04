namespace SitecoreInstaller
{
    public class DeploymentInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Sitecore { get; set; }
        public string License { get; set; }
        public string[] Modules { get; set; }
        public bool Done{ get; set; }
    }
}
