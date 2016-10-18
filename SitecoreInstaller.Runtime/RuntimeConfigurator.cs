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
            InitLogging(configureLog);

            LogAppInitializing();

            InitContainer();
            InitAppSettings();
            RunPreflightChecks();

            LogAppInitialized();
        }

        private void InitContainer()
        {
            _logger.Trace($"Initializing IocContainer...");
            var builder = new IocBuilder();
            builder.Register(new SitecoreInstallerRegistrations());
            Container = builder.Build();
            _logger.Trace($"IocContainer Initialized");
        }

        private void InitAppSettings()
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
        }

        private void RunPreflightChecks()
        {
            _logger.Trace($"Running preflight checks...");
            var allGood = true;
            var preflightChecks = Container.Resolve<IEnumerable<IPreflightCheck>>().ToList();
            foreach (var preflightCheck in preflightChecks)
            {
                var result = preflightCheck.Assert();
                if (result.IsReady)
                    _logger.Trace($"Preflight check {preflightCheck.GetType().Name} completed sucesfully");
                else
                {
                    allGood = false;
                    _logger.Error($"Preflight check {preflightCheck.GetType().Name} failed: {JsonConvert.SerializeObject(result.Issues)}");
                }
            }
            if (allGood == false)
            {
                _logger.Fatal($"Preflight checks failed. Aborting...");
            }
        }

        private static void InitLogging(Action<NLogConfigurator> configureLog)
        {
            using (var logConfigurator = new NLogConfigurator())
            {
                configureLog(logConfigurator);
                logConfigurator.Build();
            }
        }

        public IContainer Container { get; private set; }

        private void LogAppInitializing()
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
        }

        private void LogAppInitialized()
        {
            _logger.Trace($"{Host.Namespace} initialized");
            _logger.Trace("------------------------------------------------------------------------------------------------------");
        }

    }
}
