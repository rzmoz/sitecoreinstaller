namespace SitecoreInstaller
{
    public class DeploymentInfo
    {
        public DeploymentInfo()
        {
            Name = string.Empty;
            Url = string.Empty;
            Sitecore = string.Empty;
            License = string.Empty;
            Modules = new string[0];
            Task = new DeploymentTask();
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public string Sitecore { get; set; }
        public string License { get; set; }
        public string[] Modules { get; set; }

        public DeploymentTask Task { get; set; }
    }
}
