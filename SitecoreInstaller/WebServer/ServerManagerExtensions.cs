using System.Diagnostics;
using DotNet.Basics.Collections;
using Microsoft.Web.Administration;
using NLog;

namespace SitecoreInstaller.WebServer
{
    public static class ServerManagerExtensions
    {
        private static readonly ILogger _logger = LogManager.GetLogger(nameof(IisManagementService));

        public static bool AppPoolExists(this ServerManager iisManager, string appPoolName)
        {
            return iisManager.ApplicationPools[appPoolName] == null;
        }
        public static bool SiteExists(this ServerManager iisManager, string siteName)
        {
            return iisManager.Sites[siteName] == null;
        }

        public static void CreateSite(this ServerManager iisManager, SiteSettings sitesettings, AppPoolSettings appPoolSettings)
        {
            var site = iisManager.Sites.Add(sitesettings.Name, "http", sitesettings.BindingInformation, sitesettings.SiteRoot.FullName);
            site.ApplicationDefaults.ApplicationPoolName = appPoolSettings.Name;
            site.LogFile.Directory = sitesettings.IisLogFilesDir.FullName;

            _logger.Trace($"Iis site created: {sitesettings.Name}");
            _logger.Debug($"Site home directory set to '{sitesettings.SiteRoot.FullName}'");
            _logger.Debug($"Site log dir set to '{sitesettings.IisLogFilesDir.FullName}'");
            _logger.Debug($"Site App Pool set to '{appPoolSettings.Name}'");
        }

        public static void DeleteSite(this ServerManager iisManager, SiteSettings settings)
        {
            iisManager.Sites[settings.Name]?.Delete();
            _logger.Trace($"Iis site pool deleted: {settings.Name}");
        }

        public static Site GetSite(this ServerManager iisManager, SiteSettings settings)
        {
            return iisManager.Sites[settings.Name];
        }

        public static void CreateAppPool(this ServerManager iisManager, AppPoolSettings settings)
        {
            var appPool = iisManager.ApplicationPools.Add(settings.Name);
            appPool.ManagedRuntimeVersion = settings.ManagedRuntimeVersion;
            appPool.ManagedPipelineMode = settings.ManagedPipelineMode;
            appPool.Enable32BitAppOnWin64 = settings.Enable32BitAppOnWin64;
            appPool.ProcessModel.PingingEnabled = settings.PingEnabled;
            appPool.ProcessModel.IdentityType = settings.ProcessModelIdentityType;

            _logger.Trace($"App pool created: {settings.Name}");
            _logger.Debug("App pool runtime version set to {0}", appPool.ManagedRuntimeVersion);
            _logger.Debug("App pool pipeline mode set to {0}", appPool.ManagedPipelineMode);
            _logger.Debug("App pool identity set to {0}", appPool.ProcessModel.IdentityType);
        }

        public static void DeleteAppPool(this ServerManager iisManager, AppPoolSettings settings)
        {
            var appPool = iisManager.ApplicationPools[settings.Name];
            appPool?.WorkerProcesses.ParallelForEach(wp => Process.GetProcessById(wp.ProcessId).Kill());
            appPool?.Delete();
            _logger.Trace($"App pool deleted: {settings.Name}");
        }

        public static ApplicationPool GetAppPool(this ServerManager iisManager, AppPoolSettings settings)
        {
            return iisManager.ApplicationPools[settings.Name];
        }
    }
}
