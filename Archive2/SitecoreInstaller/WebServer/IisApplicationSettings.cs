using System;

namespace SitecoreInstaller.WebServer
{
    public class IisApplicationSettings
    {
        public IisApplicationSettings(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            Name = name;
            AppPoolSettings = new AppPoolSettings(Name);
            SiteSettings = new SiteSettings(Name);
        }
        public string Name { get; }
        public AppPoolSettings AppPoolSettings { get; }
        public SiteSettings SiteSettings { get; }
    }
}
