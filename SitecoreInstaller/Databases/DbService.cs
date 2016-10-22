using System;
using System.Collections.Generic;
using DotNet.Basics.Sys;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Databases
{
    public abstract class DbService : IPreflightCheck
    {
        private readonly ILogger _logger;

        protected DbService(string instanceName = null, string windowsServiceName = null)
        {
            InstanceName = instanceName;
            WindowsServiceName = windowsServiceName;
            _logger = LogManager.GetLogger(GetType().Namespace);
        }

        public string InstanceName { get; protected set; }
        public string WindowsServiceName { get; protected set; }
        public bool IsRunning => ConnectionEstablished(InstanceName);
        public bool IsWindowsServiceRunning => WindowsServices.IsRunning(WindowsServiceName);

        protected abstract bool ConnectionEstablished(string instanceName);

        public PreflightCheckResult Assert()
        {

            var dbType = GetType().Name.Replace(nameof(DbService), "");

            return new PreflightCheckResult(issues =>
            {
                if (WindowsServiceName == null)
                    issues.AddRange(AssertWindowsServiceName());

                //if windows service is found but not running and couldn't be started
                if (WindowsServiceName != null)
                    if (IsWindowsServiceRunning == false)
                        if (StartWindowsService() == false)
                            issues.Add($"Failed to start Database Windows Service: {WindowsServiceName}");
                if (IsWindowsServiceRunning)
                    _logger.Trace($"{dbType } Server Windows Service is running: {WindowsServiceName}");

                if (InstanceName == null)
                    issues.AddRange(AssertInstanceName());

                if (InstanceName != null && ConnectionEstablished(InstanceName))
                    _logger.Trace($"{dbType} Server connection is established: {InstanceName}");
            });
        }

        protected abstract IEnumerable<string> AssertWindowsServiceName();
        protected abstract IEnumerable<string> AssertInstanceName();

        public bool StartWindowsService()
        {
            if (IsRunning)
                return true;
            try
            {
                WindowsServices.Start(WindowsServiceName);
                return IsRunning == false;
            }
            catch (Exception e)
            {
                _logger.Warn(e);
                return false;
            }
        }

        public bool StopWindowsService()
        {
            if (IsRunning == false)
                return true;
            try
            {
                WindowsServices.Stop(WindowsServiceName);
                return IsRunning == false;
            }
            catch (Exception e)
            {
                _logger.Warn(e);
                return false;
            }
        }

        public bool RestartWindowsService()
        {
            bool restarted = true;

            if (IsRunning)
                restarted = StopWindowsService();

            return restarted && StartWindowsService();
        }
    }
}
