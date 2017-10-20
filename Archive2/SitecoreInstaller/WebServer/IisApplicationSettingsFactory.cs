namespace SitecoreInstaller.WebServer
{
    public class IisApplicationSettingsFactory
    {
        public IisApplicationSettings Create(string name, string url = null, DeploymentDir deploymentDir = null)
        {
            var settings = new IisApplicationSettings(name);
            settings.SiteSettings.Url = url;
            settings.SiteSettings.SiteRoot = deploymentDir?.Website;
            settings.SiteSettings.IisLogFilesDir = deploymentDir?.Add("IisLogFiles");
            return settings;
        }
    }
}
