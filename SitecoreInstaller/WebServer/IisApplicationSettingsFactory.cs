using DotNet.Basics.IO;

namespace SitecoreInstaller.WebServer
{
    public class IisApplicationSettingsFactory
    {
        private readonly EnvironmentSettings _environmentSettings;

        public IisApplicationSettingsFactory(EnvironmentSettings environmentSettings)
        {
            _environmentSettings = environmentSettings;
        }

        public IisApplicationSettings Create(string name)
        {
            var settings = new IisApplicationSettings(name);
            settings.SiteSettings.SiteRoot = _environmentSettings.SitesRootDir.ToDir(name);
            settings.SiteSettings.IisLogFilesDir = settings.SiteSettings.SiteRoot.Add("IisLogFiles");
            return settings;
        }
    }
}
