﻿using System;
using System.IO;
using Microsoft.Web.Administration;
using System.Diagnostics;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.WebServer
{
    public class IisManagementService : IIisManagementService
    {
        public IisManagementService()
        {
            HostFile = new HostFile();
        }

        public void CreateApplication(IisSettings iisSettings, DirectoryInfo siteDirectory, DirectoryInfo iisLogFilesDirectory)
        {
            Log.As.Debug("Creating application in iis: {0}", iisSettings.Name);

            using (var iisManager = new ServerManager())
            {
                if (iisManager.ApplicationPools[iisSettings.Name] != null)
                {
                    Log.As.Error("Application pool already exist in iis: {0}", iisSettings.Name);
                    return;
                }

                if (iisManager.Sites[iisSettings.Name] != null)
                {
                    Log.As.Error("Site already exist in iis: {0}", iisSettings.Name);
                    return;
                }
            }
            CreateAppPool(iisSettings);

            CreateSite(iisSettings, siteDirectory, iisLogFilesDirectory);
        }

        public void DeleteApplication(string applicationName)
        {
            using (var iisManager = new ServerManager())
            {
                if (iisManager.Sites[applicationName] == null)
                {
                    Log.As.Warning("Site not found in iis: {0}", applicationName);
                    return;
                }

                if (iisManager.ApplicationPools[applicationName] == null)
                {
                    Log.As.Error("Application pool not found in iis: {0}", applicationName);
                    return;
                }
            }



            DeleteSite(applicationName);
            DeleteAppPool(applicationName);
        }

        public void RecycleApplication(string applicationName)
        {
            using (var iisManager = new ServerManager())
            {
                if (iisManager.ApplicationPools[applicationName] == null)
                {
                    Log.As.Warning("Application pool not found: {0}", applicationName);
                    return;
                }

                iisManager.ApplicationPools[applicationName].Recycle();
                iisManager.CommitChanges();
                Log.As.Info("Application pool recycled from iis: {0}", applicationName);
            }
        }

        private void DeleteAppPool(string applicationName)
        {
            using (var iisManager = new ServerManager())
            {
                if (iisManager.ApplicationPools[applicationName] == null)
                {
                    Log.As.Warning("Application pool not found: {0}", applicationName);
                    return;
                }
                foreach (var workerProcess in iisManager.ApplicationPools[applicationName].WorkerProcesses)
                {
                    Process.GetProcessById(workerProcess.ProcessId).Kill();
                }

                iisManager.ApplicationPools[applicationName].Delete();
                iisManager.CommitChanges();
                Log.As.Info("Application pool deleted from iis: {0}", applicationName);
            }
        }

        private void DeleteSite(string applicationName)
        {
            using (var iisManager = new ServerManager())
            {
                iisManager.Sites[applicationName].Delete();
                iisManager.CommitChanges();
                Log.As.Info("Site deleted from iis: " + applicationName);
            }
        }

        public void StartApplication(string applicationName)
        {
            using (var iisManager = new ServerManager())
            {
                if (iisManager.ApplicationPools[applicationName] == null)
                    Log.As.Error("Application pool not found: " + applicationName);
                else
                {
                    if (iisManager.ApplicationPools[applicationName].State == ObjectState.Stopped)
                    {
                        iisManager.ApplicationPools[applicationName].Start();
                        Log.As.Info("Application pool started: " + applicationName);
                    }
                    else
                        Log.As.Debug("Application pool already started: " + applicationName);
                }

                if (iisManager.Sites[applicationName] == null)
                    Log.As.Error("Site not found: " + applicationName);
                else
                {
                    if (iisManager.Sites[applicationName].State == ObjectState.Stopped)
                    {
                        iisManager.Sites[applicationName].Start();
                        Log.As.Info("Site started: " + applicationName);
                    }
                    else
                        Log.As.Debug("Site already started: " + applicationName);
                }
            }
        }

        public void StopApplication(string applicationName)
        {
            using (var iisManager = new ServerManager())
            {
                if (iisManager.ApplicationPools[applicationName] == null)
                    Log.As.Warning("Application pool not found: " + applicationName);
                else
                {
                    if (iisManager.ApplicationPools[applicationName].State == ObjectState.Started)
                    {
                        iisManager.ApplicationPools[applicationName].Stop();
                        Log.As.Info("Application pool stopped: " + applicationName);
                    }
                    else
                        Log.As.Debug("Application pool already stopped: " + applicationName);
                }

                var site = iisManager.Sites[applicationName];

                if (site == null)
                    Log.As.Warning("Site not found: " + applicationName);
                else
                {
                    if (site.State == ObjectState.Started)
                    {
                        site.Stop();
                        Log.As.Info("Site stopped: " + applicationName);
                    }
                    else
                        Log.As.Debug("Site already stopped: " + applicationName);
                }
            }
        }

        public bool BindingExists(string bindingCandidate)
        {
            if (bindingCandidate == null) throw new ArgumentNullException("bindingCandidate");
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

        public HostFile HostFile { get; private set; }

        private void CreateAppPool(IisSettings iisSettings)
        {
            Log.As.Info("Creating application pool '{0}'", iisSettings.Name);

            using (var iisManager = new ServerManager())
            {
                var appPool = iisManager.ApplicationPools.Add(iisSettings.Name);
                appPool.ManagedRuntimeVersion = iisSettings.ManagedRuntimeVersion.ToString();
                appPool.ManagedPipelineMode = iisSettings.ManagedPipelineMode;
                appPool.Enable32BitAppOnWin64 = iisSettings.Enable32BitAppOnWin64;
                appPool.ProcessModel.PingingEnabled = iisSettings.PingingEnabled;
                appPool.ProcessModel.IdentityType = iisSettings.ProcessModelIdentityType;
                iisManager.CommitChanges();

                Log.As.Debug("App pool runtime version set to {0}", appPool.ManagedRuntimeVersion);
                Log.As.Debug("App pool pipeline mode set to {0}", appPool.ManagedPipelineMode);
                Log.As.Debug("App pool identity set to {0}", appPool.ProcessModel.IdentityType);

                Log.As.Info("Application pool created");
            }
        }

        private void CreateSite(IisSettings iisSettings, DirectoryInfo siteDirectory, DirectoryInfo iisLogFilesDirectory)
        {
            using (var iisManager = new ServerManager())
            {
                Log.As.Info("Creating site in iis '{0}'", iisSettings.Name);
                Log.As.Debug("Site home directory set to '{0}'", siteDirectory.FullName);
                var bindingInformation = string.Format(_bindingInformationFormat, iisSettings.Url);
                var site = iisManager.Sites.Add(iisSettings.Name, "http", bindingInformation, siteDirectory.FullName);
                site.ApplicationDefaults.ApplicationPoolName = iisSettings.Name;
                site.LogFile.Directory = iisLogFilesDirectory.FullName;
                iisManager.CommitChanges();
            }

            Log.As.Info("Site created");
        }

        private const string _bindingInformationFormat = "*:80:{0}";
    }
}
