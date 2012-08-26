﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Web.Administration;

namespace SitecoreInstaller.Domain.WebServer
{
    using SitecoreInstaller.Framework.Diagnostics;

    public class IisManagementService : IIisManagementService
    {
        private readonly ServerManager _iisManager;
        public IisManagementService()
        {
            _iisManager = new ServerManager();
        }

        public void CreateApplication(AppPoolSettings appPoolSettings, DirectoryInfo siteDirectory, DirectoryInfo iisLogFilesDirectory)
        {
            Log.As.Debug("Creating application in iis: {0}", appPoolSettings.Name);

            if (_iisManager.ApplicationPools[appPoolSettings.Name] != null)
            {
                Log.As.Error("Application pool already exist in iis: {0}", appPoolSettings.Name);
                return;
            }

            if (_iisManager.Sites[appPoolSettings.Name] != null)
            {
                Log.As.Error("Site already exist in iis: {0}", appPoolSettings.Name);
                return;
            }

            CreateAppPool(appPoolSettings);

            CreateSite(appPoolSettings.Name, siteDirectory, iisLogFilesDirectory);
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

            if (_iisManager.Sites[applicationName] == null)
                Log.As.Error("Site not found: " + applicationName);
            else
            {
                if (_iisManager.Sites[applicationName].State == ObjectState.Started)
                {
                    _iisManager.Sites[applicationName].Stop();
                    Log.As.Info("Site stopped: " + applicationName);
                }
                else
                    Log.As.Warning("Site already stopped: " + applicationName);
            }
        }

        private void CreateAppPool(AppPoolSettings appPoolSettings)
        {
            Log.As.Info("Creating application pool '{0}'", appPoolSettings.Name);

            var appPool = _iisManager.ApplicationPools.Add(appPoolSettings.Name);
            appPool.ManagedRuntimeVersion = appPoolSettings.ManagedRuntimeVersion.ToString();
            appPool.ManagedPipelineMode = appPoolSettings.ManagedPipelineMode;
            appPool.Enable32BitAppOnWin64 = appPoolSettings.Enable32BitAppOnWin64;
            appPool.ProcessModel.PingingEnabled = appPoolSettings.PingingEnabled;
            appPool.ProcessModel.IdentityType = appPoolSettings.ProcessModelIdentityType;
            _iisManager.CommitChanges();

            Log.As.Debug("App pool runtime version set to {0}", appPool.ManagedRuntimeVersion);
            Log.As.Debug("App pool pipeline mode set to {0}", appPool.ManagedPipelineMode);
            Log.As.Debug("App pool identity set to {0}", appPool.ProcessModel.IdentityType);

            Log.As.Info("Application pool created");
        }

        private void CreateSite(string applicationName, DirectoryInfo siteDirectory, DirectoryInfo iisLogFilesDirectory)
        {
            Log.As.Info("Creating site in iis '{0}'", applicationName);
            Log.As.Debug("Site home directory set to '{0}'", siteDirectory.FullName);
            var bindingInformation = string.Format(_BindingInformationFormat, applicationName);
            var site = _iisManager.Sites.Add(applicationName, "http", bindingInformation, siteDirectory.FullName);
            site.ApplicationDefaults.ApplicationPoolName = applicationName;
            site.LogFile.Directory = iisLogFilesDirectory.FullName;
            _iisManager.CommitChanges();

            Log.As.Info("Site created");
        }

        private const string _BindingInformationFormat = "*:80:{0}";
    }
}
