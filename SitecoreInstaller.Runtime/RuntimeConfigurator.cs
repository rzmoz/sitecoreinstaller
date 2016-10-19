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
            _logger = LogManager.GetLogger(host.Namespace);
        }

        public Type Host { get; }

        public void Init(Action<NLogConfigurator> configureLog)
        {

            var initStatus = InitLogging(configureLog);

            initStatus = initStatus && LogAppInitializing();

            initStatus = initStatus && InitContainer();
            initStatus = initStatus && InitAppSettings();
            initStatus = initStatus && RunPreflightChecks();

            LogAppInitialized(initStatus);
        }

        private bool InitContainer()
        {
            _logger.Trace($"Initializing IocContainer...");
            var builder = new IocBuilder();
            builder.Register(new SitecoreInstallerRegistrations());
            Container = builder.Build();
            _logger.Trace($"IocContainer Initialized");
            return true;
        }

        private bool InitAppSettings()
        {
            _logger.Trace($"Verifying App Settings...");
            var appSettingsResult = Container.VerifyRequiredAppSettingKeysAreConfigured();
            if (appSettingsResult.AllGood)
                _logger.Trace($"App Settings verified");
            else
            {
                foreach (var missingKey in appSettingsResult.MissingKeys)
                    _logger.Error($"Required key is not configured: {missingKey}");

                _logger.Fatal($"App settings not configured properly. Application will not run properly. Aborting...");
            }
            return appSettingsResult.AllGood;
        }

        private bool RunPreflightChecks()
        {
            _logger.Trace($"Running Preflight checks...");
            var allGood = true;
            var preflightChecks = Container.Resolve<IEnumerable<IPreflightCheck>>().ToList();
            foreach (var preflightCheck in preflightChecks)
            {
                var result = preflightCheck.Assert();
                if (result.IsReady)
                    _logger.Trace($"Preflight check {preflightCheck.GetType().Name} completed successfully");
                else
                {
                    allGood = false;
                    _logger.Error($"Preflight check {preflightCheck.GetType().Name} failed:\r\n{JsonConvert.SerializeObject(result.Issues)}");
                }
            }
            if (allGood)
                _logger.Trace($"Preflight checks completed successfully");
            else
                _logger.Fatal($"Preflight checks failed. Aborting...");

            return allGood;
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
            _logger.Trace($"{Host.Namespace} initializing...");
            _logger.Info($"UTC Time: {DateTime.UtcNow}");
            _logger.Info($"Host Version: {FileVersionInfo.GetVersionInfo(Host.Assembly.Location).FileVersion}");
            return true;
        }

        private void LogAppInitialized(bool appInitialized)
        {
            _logger.Trace(appInitialized
                ? $"{Host.Namespace} initialized"
                : $"Initialization of {Host.Namespace} failed");
            _logger.Trace("------------------------------------------------------------------------------------------------------");
        }
    }
}
