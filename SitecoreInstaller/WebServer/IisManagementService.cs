using System;
using System.Diagnostics;
using DotNet.Basics.Collections;
using DotNet.Basics.NLog;
using DotNet.Basics.Tasks;
using Microsoft.Web.Administration;
using NLog;

namespace SitecoreInstaller.WebServer
{
    public class IisManagementService : IPreflightCheck
    {
        private readonly IisApplicationSettingsFactory _iisApplicationSettingsFactory;

        public IisManagementService(IisApplicationSettingsFactory iisApplicationSettingsFactory)
        {
            _iisApplicationSettingsFactory = iisApplicationSettingsFactory;
        }

        public void CreateApplication(string name, string url, DeploymentDir deploymentDir)
        {
            var settings = _iisApplicationSettingsFactory.Create(name, url, deploymentDir);
            this.NLog().Trace($"Creating Iis Application: {settings.Name}...");
            using (var iisManager = new IisManager(settings))
            {
                CreateAppPool(iisManager.ServerManager, settings.AppPoolSettings);
                CreateSite(iisManager.ServerManager, settings.SiteSettings, settings.AppPoolSettings);
            }
            settings.SiteSettings.SiteRoot.CreateIfNotExists();
            this.NLog().Debug($"{nameof(settings.SiteSettings.SiteRoot)} created: {settings.SiteSettings.SiteRoot.FullName}");
            settings.SiteSettings.IisLogFilesDir.CreateIfNotExists();
            this.NLog().Trace($"Iis Application created: {settings.Name}");
        }

        public void DeleteApplication(string name)
        {
            var settings = _iisApplicationSettingsFactory.Create(name);
            this.NLog().Trace($"Deleting Iis Application: {settings.Name}...");
            using (var iisManager = new IisManager(settings))
            {
                iisManager.Site(site => site?.Delete());
                this.NLog().Debug($"Website deleted: {settings.SiteSettings.Name}");
                iisManager.AppPool(appPool =>
                {
                    appPool?.WorkerProcesses.ParallelForEach(wp => Process.GetProcessById(wp.ProcessId).Kill());
                    appPool?.Delete();
                    this.NLog().Debug($"App pool deleted: {settings.AppPoolSettings.Name}");
                });
            }

            this.NLog().Trace($"Iis Application deleted: {settings.Name}");
        }

        public void RecycleApplication(string name)
        {
            var settings = _iisApplicationSettingsFactory.Create(name);
            using (var iisManager = new IisManager(settings))
            {
                iisManager.AppPool(appPool => appPool?.Recycle());
            }
        }

        public void StartApplication(string name)
        {
            var settings = _iisApplicationSettingsFactory.Create(name);
            using (var iisManager = new IisManager(settings))
            {
                iisManager.AppPool(appPool => appPool?.Start());
                this.NLog().Debug($"Iis App Pool started: {settings.AppPoolSettings.Name}");
                iisManager.Site(site => site?.Start());
                this.NLog().Debug($"Iis Site started: {settings.SiteSettings.Name}");
            }
            this.NLog().Trace($"Iis Application started: {settings.Name}");
        }

        public void StopApplication(string name)
        {
            var settings = _iisApplicationSettingsFactory.Create(name);
            using (var iisManager = new IisManager(settings))
            {
                iisManager.Site(site => site?.Stop());
                this.NLog().Debug($"Iis Site stopped: {settings.SiteSettings.Name}");
                iisManager.AppPool(appPool => appPool?.Stop());
                this.NLog().Debug($"Iis App Pool stopped: {settings.AppPoolSettings.Name}");
            }
            this.NLog().Debug($"Iis Application stopped: {settings.Name}");
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

        public TaskResult Assert()
        {
            return new TaskResult(issues =>
            {
                try
                {
                    using (var mng = new IisManager(new IisApplicationSettings(string.Empty)))
                    {
                        //verify connection
                        mng.ServerManager.CommitChanges();
                        this.NLog().Trace($"Connection to Iis Management Services established");
                    }
                }
                catch (Exception e)
                {
                    issues.Add(e.ToString());
                }
            });
        }

        private void CreateSite(ServerManager iisManager, SiteSettings sitesettings, AppPoolSettings appPoolSettings)
        {
            var site = iisManager.Sites.Add(sitesettings.Name, sitesettings.BindingProtocol, sitesettings.BindingInformation, sitesettings.SiteRoot.FullName);
            site.ApplicationDefaults.ApplicationPoolName = appPoolSettings.Name;
            site.LogFile.Directory = sitesettings.IisLogFilesDir.FullName;

            this.NLog().Debug($"Site home directory set to '{sitesettings.SiteRoot.FullName}'");
            this.NLog().Debug($"Site log dir set to '{sitesettings.IisLogFilesDir.FullName}'");
            this.NLog().Debug($"Site bindings set to  '{sitesettings.BindingInformation}'");
            this.NLog().Debug($"Site App Pool set to '{site.ApplicationDefaults.ApplicationPoolName}'");
            this.NLog().Debug($"Iis Site created: {sitesettings.Name}");
        }

        private void CreateAppPool(ServerManager iisManager, AppPoolSettings settings)
        {
            var appPool = iisManager.ApplicationPools.Add(settings.Name);
            appPool.ManagedRuntimeVersion = settings.ManagedRuntimeVersion;
            appPool.ManagedPipelineMode = settings.ManagedPipelineMode;
            appPool.Enable32BitAppOnWin64 = settings.Enable32BitAppOnWin64;
            appPool.ProcessModel.PingingEnabled = settings.PingEnabled;
            appPool.ProcessModel.IdentityType = settings.ProcessModelIdentityType;

            this.NLog().Debug("App pool runtime version set to {0}", appPool.ManagedRuntimeVersion);
            this.NLog().Debug("App pool pipeline mode set to {0}", appPool.ManagedPipelineMode);
            this.NLog().Debug("App pool identity set to {0}", appPool.ProcessModel.IdentityType);
            this.NLog().Debug($"App pool created: {settings.Name}");
        }
    }
}

