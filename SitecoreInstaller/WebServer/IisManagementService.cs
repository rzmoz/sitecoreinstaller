using System;
using System.Diagnostics;
using DotNet.Basics.Collections;
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
            _logger.Trace($"Creating Iis Application: {settings.Name}...");
            using (var iisManager = new IisManager(settings))
            {
                CreateAppPool(iisManager.ServerManager, settings.AppPoolSettings);
                CreateSite(iisManager.ServerManager, settings.SiteSettings, settings.AppPoolSettings);
            }
            settings.SiteSettings.SiteRoot.CreateIfNotExists();
            _logger.Debug($"{nameof(settings.SiteSettings.SiteRoot)} created: {settings.SiteSettings.SiteRoot.FullName}");
            settings.SiteSettings.IisLogFilesDir.CreateIfNotExists();
            _logger.Trace($"Iis Application created: {settings.Name}");
        }

        public void DeleteApplication(IisApplicationSettings settings)
        {
            _logger.Trace($"Deleting Iis Application: {settings.Name}...");
            using (var iisManager = new IisManager(settings))
            {
                iisManager.Site(site => site?.Delete());
                _logger.Debug($"Website deleted: {settings.SiteSettings.Name}");
                iisManager.AppPool(appPool =>
                {
                    appPool?.WorkerProcesses.ParallelForEach(wp => Process.GetProcessById(wp.ProcessId).Kill());
                    appPool?.Delete();
                    _logger.Debug($"App pool deleted: {settings.AppPoolSettings.Name}");
                });
            }
            settings.SiteSettings.SiteRoot.DeleteIfExists();
            _logger.Debug($"{nameof(settings.SiteSettings.SiteRoot)} deleted: {settings.SiteSettings.SiteRoot.FullName}");
            settings.SiteSettings.IisLogFilesDir.DeleteIfExists();
            _logger.Trace($"Iis Application deleted: {settings.Name}");
        }

        public void RecycleApplication(IisApplicationSettings settings)
        {
            using (var iisManager = new IisManager(settings))
            {
                iisManager.AppPool(appPool => appPool?.Recycle());
            }
        }

        public void StartApplication(IisApplicationSettings settings)
        {
            using (var iisManager = new IisManager(settings))
            {
                iisManager.AppPool(appPool => appPool?.Start());
                _logger.Debug($"Iis App Pool started: {settings.AppPoolSettings.Name}");
                iisManager.Site(site => site?.Start());
                _logger.Debug($"Iis Site started: {settings.SiteSettings.Name}");
            }
            _logger.Trace($"Iis Application started: {settings.Name}");
        }

        public void StopApplication(IisApplicationSettings settings)
        {
            using (var iisManager = new IisManager(settings))
            {
                iisManager.Site(site => site?.Stop());
                _logger.Debug($"Iis Site stopped: {settings.SiteSettings.Name}");
                iisManager.AppPool(appPool => appPool?.Stop());
                _logger.Debug($"Iis App Pool stopped: {settings.AppPoolSettings.Name}");
            }
            _logger.Debug($"Iis Application stopped: {settings.Name}");
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

        private void CreateSite(ServerManager iisManager, SiteSettings sitesettings, AppPoolSettings appPoolSettings)
        {
            var site = iisManager.Sites.Add(sitesettings.Name, sitesettings.BindingProtocol, sitesettings.BindingInformation, sitesettings.SiteRoot.FullName);
            site.ApplicationDefaults.ApplicationPoolName = appPoolSettings.Name;
            site.LogFile.Directory = sitesettings.IisLogFilesDir.FullName;

            _logger.Debug($"Site home directory set to '{sitesettings.SiteRoot.FullName}'");
            _logger.Debug($"Site log dir set to '{sitesettings.IisLogFilesDir.FullName}'");
            _logger.Debug($"Site App Pool set to '{site.ApplicationDefaults.ApplicationPoolName}'");
            _logger.Debug($"Iis Site created: {sitesettings.Name}");
        }

        private void CreateAppPool(ServerManager iisManager, AppPoolSettings settings)
        {
            var appPool = iisManager.ApplicationPools.Add(settings.Name);
            appPool.ManagedRuntimeVersion = settings.ManagedRuntimeVersion;
            appPool.ManagedPipelineMode = settings.ManagedPipelineMode;
            appPool.Enable32BitAppOnWin64 = settings.Enable32BitAppOnWin64;
            appPool.ProcessModel.PingingEnabled = settings.PingEnabled;
            appPool.ProcessModel.IdentityType = settings.ProcessModelIdentityType;

            _logger.Debug("App pool runtime version set to {0}", appPool.ManagedRuntimeVersion);
            _logger.Debug("App pool pipeline mode set to {0}", appPool.ManagedPipelineMode);
            _logger.Debug("App pool identity set to {0}", appPool.ProcessModel.IdentityType);
            _logger.Debug($"App pool created: {settings.Name}");
        }
    }
}

