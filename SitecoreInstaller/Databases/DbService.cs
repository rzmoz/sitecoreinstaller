using System;
using System.Collections.Generic;
using DotNet.Basics.Sys;
using Newtonsoft.Json;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Databases
{
    public abstract class DbService : IPreflightCheck
    {
        protected DbService(string instanceName = null, string windowsServiceName = null)
        {
            InstanceName = instanceName;
            WindowsServiceName = windowsServiceName;
            Logger = LogManager.GetLogger(GetType().Namespace);
        }

        protected ILogger Logger { get; }

        public string InstanceName { get; protected set; }
        public string WindowsServiceName { get; protected set; }
        public bool IsConnected => ConnectionEstablished(InstanceName);
        public bool IsWindowsServiceRunning => WindowsServices.Is(WindowsServiceName, WindowsServiceStatus.Running);
        public bool IsWindowsServiceStopped => WindowsServices.Is(WindowsServiceName, WindowsServiceStatus.Stopped);

        protected abstract bool ConnectionEstablished(string instanceName);

        public PreflightCheckResult Assert()
        {
            var dbType = GetType().Name.Replace(nameof(DbService), "");

            return new PreflightCheckResult(issues =>
            {
                if (WindowsServiceName == null)
                {
                    foreach (var serviceName in GetWindowsServiceNameCandidates())
                    {
                        if (WindowsServices.Exists(serviceName))
                        {
                            WindowsServiceName = serviceName;
                            break;
                        }
                    }
                    if (WindowsServiceName == null)
                    {
                        issues.Add($"{dbType} Server Windows Service not found. Was looking for {JsonConvert.SerializeObject(GetWindowsServiceNameCandidates())}");
                        return;
                    }
                }

                //if windows service is found but not running and couldn't be started
                if (IsWindowsServiceRunning == false)
                {
                    Logger.Debug($"Starting {dbType} Database Windows Service: {WindowsServiceName}...");
                    if (StartWindowsService() == false && IsWindowsServiceRunning == false)
                    {
                        issues.Add($"Failed to start Database Windows Service: {WindowsServiceName}");
                        return;
                    }
                }

                if (IsWindowsServiceRunning)
                    Logger.Trace($"{dbType } Server Windows Service is running: {WindowsServiceName}");

                if (InstanceName != null)
                    return;

                foreach (var instanceName in GetInstanceNameCandidates())
                {
                    if (ConnectionEstablished(instanceName))
                    {
                        InstanceName = instanceName;
                        break;
                    }
                }
                if (InstanceName != null && ConnectionEstablished(InstanceName))
                    Logger.Trace($"{dbType} Server connection is established: {InstanceName}");
                else
                    issues.Add($"Failed to connect to {dbType} Server. Tried {JsonConvert.SerializeObject(GetInstanceNameCandidates())}");
            });
        }

        protected abstract IEnumerable<string> GetWindowsServiceNameCandidates();
        protected abstract IEnumerable<string> GetInstanceNameCandidates();

        public bool StartWindowsService()
        {
            if (IsWindowsServiceRunning)
                return true;
            try
            {
                WindowsServices.Start(WindowsServiceName);
                return IsWindowsServiceRunning;
            }
            catch (Exception e)
            {
                Logger.Warn(e);
                return false;
            }
        }

        public bool StopWindowsService()
        {
            if (IsWindowsServiceStopped)
                return true;
            try
            {
                WindowsServices.Stop(WindowsServiceName);
                return IsWindowsServiceStopped;
            }
            catch (Exception e)
            {
                Logger.Warn(e);
                return false;
            }
        }

        public bool RestartWindowsService()
        {
            WindowsServices.Restart(WindowsServiceName);
            return IsWindowsServiceRunning;
        }
    }
}
