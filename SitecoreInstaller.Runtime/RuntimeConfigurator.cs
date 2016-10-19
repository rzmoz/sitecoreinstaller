using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autofac;
using DotNet.Basics.AppSettings;
using DotNet.Basics.Ioc;
using DotNet.Basics.NLog;
using Newtonsoft.Json;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Runtime
{
    public class RuntimeConfigurator
    {
        private readonly ILogger _logger;

        public RuntimeConfigurator(Type host)
        {
            Host = host;
            AppName = host.Namespace;
            _logger = LogManager.GetLogger(AppName);
        }

        public Type Host { get; }
        public string AppName { get; }

        public bool Init(Action<NLogConfigurator> configureLog, Action<IocBuilder> iocRegistrations = null)
        {
            var initStatus = InitLogging(configureLog);

            initStatus = initStatus && LogAppInitializing();

            initStatus = initStatus && InitContainer(iocRegistrations);
            initStatus = initStatus && InitAppSettings();
            initStatus = initStatus && RunPreflightChecks();

            LogAppInitialized(initStatus);

            return initStatus;
        }

        private bool InitContainer(Action<IocBuilder> iocRegistrations)
        {
            return InitArea("IocContainer", (errorMsgs) =>
            {
                try
                {
                    var builder = new IocBuilder();
                    builder.Register(new SitecoreInstallerRegistrations());
                    iocRegistrations?.Invoke(builder);
                    Container = builder.Container;
                }
                catch (Exception e)
                {
                    errorMsgs.Add(e.ToString());
                }
            });
        }

        private bool InitAppSettings()
        {
            return InitArea("App Settings", (errorMsgs) =>
            {
                var appsettings = Container.GetAppSettings();
                foreach (var appsetting in appsettings)
                {
                    _logger.Debug($"Running Preflight check: {appsetting.GetType().Name}");
                    var assert = appsetting.Verify();
                    if (assert == false)
                        errorMsgs.Add($"Required key is not configured: {appsetting.Key}");
                }
            });
        }

        private bool RunPreflightChecks()
        {
            return InitArea("Preflight Checks", (errorMsgs) =>
            {
                var preflightChecks = Container.Resolve<IEnumerable<IPreflightCheck>>().ToList();
                foreach (var preflightCheck in preflightChecks)
                {
                    _logger.Debug($"Running Preflight check: {preflightCheck.GetType().Name}");
                    var result = preflightCheck.Assert();
                    if (result.IsReady == false)
                        errorMsgs.Add($"Preflight check {preflightCheck.GetType().Name} failed:\r\n{JsonConvert.SerializeObject(result.Issues)}");
                }
            }, "Running", "Ran");
        }

        private static bool InitLogging(Action<NLogConfigurator> configureLog)
        {
            using (var logConfigurator = new NLogConfigurator())
            {
                configureLog(logConfigurator);
                logConfigurator.Build();
                return true;
            }
        }

        public IContainer Container { get; private set; }

        private bool LogAppInitializing()
        {
            _logger.Trace("------------------------------------------------------------------------------------------------------");
            _logger.Trace(@"
              ____  _ _                          ___           _        _ _           
             / ___|(_) |_ ___  ___ ___  _ __ ___|_ _|_ __  ___| |_ __ _| | | ___ _ __ 
             \___ \| | __/ _ \/ __/ _ \| '__/ _ \| || '_ \/ __| __/ _` | | |/ _ \ '__|
              ___) | | ||  __/ (_| (_) | | |  __/| || | | \__ \ || (_| | | |  __/ |   
             |____/|_|\__\___|\___\___/|_|  \___|___|_| |_|___/\__\__,_|_|_|\___|_|

");
            _logger.Trace("------------------------------------------------------------------------------------------------------");
            _logger.Info($"{Host.Namespace} initializing...");
            _logger.Info($"UTC Time: {DateTime.UtcNow}");
            _logger.Info($"Host Version: {FileVersionInfo.GetVersionInfo(Host.Assembly.Location).FileVersion}");
            _logger.Info($"Running as: {System.Security.Principal.WindowsIdentity.GetCurrent().Name}");

            return true;
        }

        private void LogAppInitialized(bool appInitialized)
        {
            _logger.Info(appInitialized
                ? $"{Host.Namespace} initialized"
                : $"Initialization of {Host.Namespace} failed");
            _logger.Trace("------------------------------------------------------------------------------------------------------");
        }

        private bool InitArea(string areaName, Action<IList<string>> initFunc, string startingVerb = "Initializing", string endedVerb = "Initialized")
        {
            _logger.Trace($"{startingVerb} {areaName}...");
            var errorMessages = new List<string>();
            initFunc(errorMessages);
            var success = errorMessages.Count == 0;
            if (success)
                _logger.Trace($"{areaName} {endedVerb} successfully");
            else
            {
                foreach (var errorMessage in errorMessages)
                    _logger.Error(errorMessage);

                _logger.Fatal($"{startingVerb} of {areaName} failed. Application will not run properly. Aborting...");
            }
            return success;
        }
    }
}
