using System;
using System.Collections.Generic;
using DotNet.Basics.NLog;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks;
using Newtonsoft.Json;
using NLog;

namespace SitecoreInstaller.Databases
{
    public abstract class DbService : IPreflightCheck
    {
        protected DbService() : this(null, null) { }
        protected DbService(string instanceName) : this(instanceName, null) { }
        protected DbService(string instanceName, string windowsServiceName)
        {
            InstanceName = instanceName;
            WindowsServiceName = windowsServiceName;
        }

        public string InstanceName { get; protected set; }
        public string WindowsServiceName { get; protected set; }
        public bool IsConnected => ConnectionEstablished(InstanceName);
        public bool IsWindowsServiceRunning => WindowsServices.Is(WindowsServiceName, WindowsServiceStatus.Running);
        public bool IsWindowsServiceStopped => WindowsServices.Is(WindowsServiceName, WindowsServiceStatus.Stopped);

        protected abstract bool ConnectionEstablished(string instanceName);
        protected abstract IEnumerable<string> GetWindowsServiceNameCandidates();
        protected abstract IEnumerable<string> GetInstanceNameCandidates();
        protected abstract void CustomAssert(TaskIssueList issues);

        protected void WorkOnConnectionStrings<T>(Func<IEnumerable<T>> getEnumerator, Action<T> action, string startingVerb, string endedVerb) where T : DbConnectionString
        {
            foreach (var conStr in getEnumerator())
            {
                this.NLog().Debug($"{startingVerb.ToTitleCase()} {conStr.DbType} Database: {conStr.DatabaseName}...");
                try
                {
                    action(conStr);
                    this.NLog().Trace($"{conStr.DbType} Database {conStr.DatabaseName} {endedVerb.ToLowerInvariant()}");
                }
                catch (Exception e)
                {
                    this.NLog().Error($"{startingVerb.ToTitleCase()} {conStr.DbType} {conStr.DatabaseName} failed: {e}");
                }
            }
        }

        public TaskResult Assert()
        {
            var dbType = GetType().Name.Replace(nameof(DbService), "");

            return new TaskResult(issues =>
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
                    this.NLog().Debug($"Starting {dbType} Database Windows Service: {WindowsServiceName}...");
                    if (StartWindowsService() == false && IsWindowsServiceRunning == false)
                    {
                        issues.Add($"Failed to start Database Windows Service: {WindowsServiceName}");
                        return;
                    }
                }

                if (IsWindowsServiceRunning)
                    this.NLog().Trace($"{dbType } Server Windows Service is running: {WindowsServiceName}");

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
                {
                    this.NLog().Trace($"{dbType} Server connection is established: {InstanceName}");
                    CustomAssert(issues);
                }
                else
                    issues.Add($"Failed to connect to {dbType} Server. Tried {JsonConvert.SerializeObject(GetInstanceNameCandidates())}");
            });
        }

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
                this.NLog().Warn(e);
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
                this.NLog().Warn(e);
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
