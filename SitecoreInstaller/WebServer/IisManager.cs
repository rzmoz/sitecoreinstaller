using System;
using Microsoft.Web.Administration;

namespace SitecoreInstaller.WebServer
{
    public class IisManager : IDisposable
    {
        private readonly IisApplicationSettings _settings;

        public IisManager(IisApplicationSettings settings)
        {
            _settings = settings;
            ServerManager = new ServerManager();
        }

        public ServerManager ServerManager { get; }
        
        public void AppPool(Action<ApplicationPool> appPoolAction)
        {
            appPoolAction(ServerManager.ApplicationPools[_settings.AppPoolSettings.Name]);
        }
        public void Site(Action<Site> siteAction)
        {
            siteAction(ServerManager.Sites[_settings.SiteSettings.Name]);
        }

        public void Dispose()
        {
            ServerManager?.CommitChanges();
            ServerManager?.Dispose();
        }
    }
}
