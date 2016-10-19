using System;
using DotNet.Basics.IO;
using Microsoft.Web.Administration;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.WebServer
{
    public class IisManagementService : IPreflightCheck
    {
        private readonly ILogger _logger;

        public IisManagementService()
        {
            _logger = LogManager.GetLogger(nameof(IisManagementService));
        }

        public void CreateApplication(IisApplicationSettings settings)
        {
            using (var iisManager = new ServerManager())
            {
                iisManager.CreateAppPool(settings.AppPoolSettings);
                iisManager.CreateSite(settings.SiteSettings, settings.AppPoolSettings);
                iisManager.CommitChanges();
            }
            settings.SiteSettings.SiteRoot.CreateIfNotExists();
            settings.SiteSettings.IisLogFilesDir.CreateIfNotExists();
        }

        public void DeleteApplication(IisApplicationSettings settings)
        {
            using (var iisManager = new ServerManager())
            {
                iisManager.DeleteSite(settings.SiteSettings);
                iisManager.DeleteAppPool(settings.AppPoolSettings);
                iisManager.CommitChanges();
            }
            settings.SiteSettings.SiteRoot.DeleteIfExists();
            settings.SiteSettings.IisLogFilesDir.DeleteIfExists();
        }

        public void RecycleApplication(string applicationName)
        {
            using (var iisManager = new ServerManager())
            {
                iisManager.ApplicationPools[applicationName]?.Recycle();
                iisManager.CommitChanges();
            }
        }

        public void StartApplication(IisApplicationSettings settings)
        {
            using (var iisManager = new ServerManager())
            {
                var site = iisManager.GetSite(settings.SiteSettings);
                site?.Start();
                _logger.Trace($"Iis Site started: {settings.SiteSettings.Name}");
                var appPool = iisManager.GetAppPool(settings.AppPoolSettings);
                appPool?.Start();
                _logger.Trace($"Iis App Pool started: {settings.AppPoolSettings.Name}");
            }
        }

        public void StopApplication(IisApplicationSettings settings)
        {
            using (var iisManager = new ServerManager())
            {
                var site = iisManager.GetSite(settings.SiteSettings);
                site?.Stop();
                _logger.Trace($"Iis Site stopped: {settings.SiteSettings.Name}");
                var appPool = iisManager.GetAppPool(settings.AppPoolSettings);
                appPool?.Stop();
                _logger.Trace($"Iis App Pool stopped: {settings.AppPoolSettings.Name}");
            }
        }

        public bool BindingExists(string bindingCandidate)
        {
            if (bindingCandidate == null) throw new ArgumentNullException(nameof(bindingCandidate));
            if (bindingCandidate.Length == 0)
                return false;

            using (var iisManager = new ServerManager())
            {
                foreach (var site in iisManager.Sites)
                {
                    foreach (var binding in site.Bindings)
                    {
                        if (binding.Host.Equals(bindingCandidate, StringComparison.InvariantCultureIgnoreCase))
                            return true;
                    }
                }
            }

            return false;
        }

        public PreflightCheckResult Assert()
        {
            return new PreflightCheckResult();
        }
    }
}

