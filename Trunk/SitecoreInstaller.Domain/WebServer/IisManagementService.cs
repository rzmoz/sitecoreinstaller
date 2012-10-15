using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Web.Administration;

namespace SitecoreInstaller.Domain.WebServer
{
    using System.Diagnostics;
    using System.Linq;

    using SitecoreInstaller.Framework.Diagnostics;

    public class IisManagementService : IIisManagementService
    {
        private readonly ServerManager _iisManager;
        public IisManagementService()
        {
            _iisManager = new ServerManager();
            HostFile = new HostFile();
        }

        public void CreateApplication(IisSettings iisSettings, DirectoryInfo siteDirectory, DirectoryInfo iisLogFilesDirectory)
        {
            Log.As.Debug("Creating application in iis: {0}", iisSettings.Name);

            if (_iisManager.ApplicationPools[iisSettings.Name] != null)
            {
                Log.As.Error("Application pool already exist in iis: {0}", iisSettings.Name);
                return;
            }

            if (_iisManager.Sites[iisSettings.Name] != null)
            {
                Log.As.Error("Site already exist in iis: {0}", iisSettings.Name);
                return;
            }

            CreateAppPool(iisSettings);

            CreateSite(iisSettings, siteDirectory, iisLogFilesDirectory);
        }

        public void DeleteApplication(string applicationName)
        {
            if (_iisManager.Sites[applicationName] == null)
            {
                Log.As.Error("Site not found in iis: {0}", applicationName);
                return;
            }

            if (_iisManager.ApplicationPools[applicationName] == null)
            {
                Log.As.Error("Application pool not found in iis: {0}", applicationName);
                return;
            }

            DeleteSite(applicationName);
            DeleteAppPool(applicationName);
        }

        private void DeleteAppPool(string applicationName)
        {
            if (_iisManager.ApplicationPools[applicationName] == null)
            {
                Log.As.Warning("Application pool not found: {0}", applicationName);
                return;
            }
            foreach (var workerProcess in _iisManager.ApplicationPools[applicationName].WorkerProcesses)
            {
                Process.GetProcessById(workerProcess.ProcessId).Kill();
            }

            _iisManager.ApplicationPools[applicationName].Delete();
            _iisManager.CommitChanges();
            Log.As.Info("Application pool deleted from iis: {0}", applicationName);
        }

        private void DeleteSite(string applicationName)
        {
            _iisManager.Sites[applicationName].Delete();
            _iisManager.CommitChanges();
            Log.As.Info("Site deleted from iis: " + applicationName);
        }

        public void StartApplication(string applicationName)
        {
            if (_iisManager.ApplicationPools[applicationName] == null)
                Log.As.Error("Application pool not found: " + applicationName);
            else
            {
                if (_iisManager.ApplicationPools[applicationName].State == ObjectState.Stopped)
                {
                    _iisManager.ApplicationPools[applicationName].Start();
                    Log.As.Info("Application pool started: " + applicationName);
                }
                else
                    Log.As.Warning("Application pool already started: " + applicationName);
            }

            if (_iisManager.Sites[applicationName] == null)
                Log.As.Error("Site not found: " + applicationName);
            else
            {
                if (_iisManager.Sites[applicationName].State == ObjectState.Stopped)
                {
                    _iisManager.Sites[applicationName].Start();
                    Log.As.Info("Site started: " + applicationName);
                }
                else
                    Log.As.Warning("Site already started: " + applicationName);
            }
        }

        public void StopApplication(string applicationName)
        {
            if (_iisManager.ApplicationPools[applicationName] == null)
                Log.As.Error("Application pool not found: " + applicationName);
            else
            {
                if (_iisManager.ApplicationPools[applicationName].State == ObjectState.Started)
                {
                    _iisManager.ApplicationPools[applicationName].Stop();
                    Log.As.Info("Application pool stopped: " + applicationName);
                }
                else
                    Log.As.Warning("Application pool already stopped: " + applicationName);
            }

            var site = _iisManager.Sites[applicationName];

            if (site == null)
                Log.As.Error("Site not found: " + applicationName);
            else
            {
                if (site.State == ObjectState.Started)
                {
                    site.Stop();
                    Log.As.Info("Site stopped: " + applicationName);
                }
                else
                    Log.As.Warning("Site already stopped: " + applicationName);
            }
        }

        public bool BindingExists(string bindingCandidate)
        {
            if (bindingCandidate == null) throw new ArgumentNullException("bindingCandidate");
            if (bindingCandidate.Length == 0)
                return false;
            foreach (var site in _iisManager.Sites)
            {
                foreach (var binding in site.Bindings)
                {
                    if (binding.Host.Equals(bindingCandidate, StringComparison.InvariantCultureIgnoreCase))
                        return true;
                }
            }
            return false;
        }

        public HostFile HostFile { get; private set; }

        private void CreateAppPool(IisSettings iisSettings)
        {
            Log.As.Info("Creating application pool '{0}'", iisSettings.Name);

            var appPool = _iisManager.ApplicationPools.Add(iisSettings.Name);
            appPool.ManagedRuntimeVersion = iisSettings.ManagedRuntimeVersion.ToString();
            appPool.ManagedPipelineMode = iisSettings.ManagedPipelineMode;
            appPool.Enable32BitAppOnWin64 = iisSettings.Enable32BitAppOnWin64;
            appPool.ProcessModel.PingingEnabled = iisSettings.PingingEnabled;
            appPool.ProcessModel.IdentityType = iisSettings.ProcessModelIdentityType;
            _iisManager.CommitChanges();

            Log.As.Debug("App pool runtime version set to {0}", appPool.ManagedRuntimeVersion);
            Log.As.Debug("App pool pipeline mode set to {0}", appPool.ManagedPipelineMode);
            Log.As.Debug("App pool identity set to {0}", appPool.ProcessModel.IdentityType);

            Log.As.Info("Application pool created");
        }

        private void CreateSite(IisSettings iisSettings, DirectoryInfo siteDirectory, DirectoryInfo iisLogFilesDirectory)
        {
            Log.As.Info("Creating site in iis '{0}'", iisSettings.Name);
            Log.As.Debug("Site home directory set to '{0}'", siteDirectory.FullName);
            var bindingInformation = string.Format(_BindingInformationFormat, iisSettings.Url);
            var site = _iisManager.Sites.Add(iisSettings.Name, "http", bindingInformation, siteDirectory.FullName);
            site.ApplicationDefaults.ApplicationPoolName = iisSettings.Name;
            site.LogFile.Directory = iisLogFilesDirectory.FullName;
            _iisManager.CommitChanges();

            Log.As.Info("Site created");
        }

        private const string _BindingInformationFormat = "*:80:{0}";
    }
}
