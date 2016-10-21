using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autofac;
using DotNet.Basics;
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

        public RuntimeConfigurator(string hostName = null)
        {
            HostName = hostName;
            if (HostName == null)
            {
                var frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType;
                HostName = type?.Namespace ?? "Host";
            }
            _logger = LogManager.GetLogger(HostName);
        }

        public string HostName { get; }

        public bool Init(Action<NLogConfigurator> configureLog, Action<IContainer, ILogger> startHostAction,
            Action<IocBuilder> iocRegistrations = null)
        {
            //ensure all low level dotnet.basics events are logged
            DebugOut.Out += _logger.Debug;

            var initStatus = InitLogging(configureLog);
            initStatus = initStatus && LogAppInitializing();
            initStatus = initStatus && InitContainer(iocRegistrations);
            initStatus = initStatus && InitAppSettings();
            initStatus = initStatus && RunPreflightChecks();

            LogAppInitialized(initStatus);

            if (initStatus == false)
                return false;

            return StartHost(startHostAction);
        }

        private bool StartHost(Action<IContainer, ILogger> startHostAction)
        {
            _logger.Debug($"Host:{HostName} starting...");

            try
            {
                startHostAction(Container, _logger);
                _logger.Info($"Host:{HostName} started");
                return true;
            }
            catch (Exception e)
            {
                _logger.Fatal(e);
                return false;
            }
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
            return InitArea("Preflight checks", (errorMsgs) =>
            {
                var preflightChecks = Container.Resolve<IEnumerable<IPreflightCheck>>().ToList();
                foreach (var preflightCheck in preflightChecks)
                {
                    _logger.Debug($"Preflight check: {preflightCheck.GetType().Name} started..");
                    var result = preflightCheck.Assert();
                    if (result.IsReady)
                        _logger.Debug($"Preflight check: {preflightCheck.GetType().Name} finished");
                    else
                        errorMsgs.Add($"Preflight check {preflightCheck.GetType().Name} failed:\r\n{JsonConvert.SerializeObject(result.Issues)}");
                }
            }, "Starting", "Finished");
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
            _logger.Debug($"Runtime initializing...");
            _logger.Trace($"UTC Time: {DateTime.UtcNow}");
            _logger.Trace($"Host Version: {FileVersionInfo.GetVersionInfo(typeof(RuntimeConfigurator).Assembly.Location).FileVersion}");
            _logger.Trace($"Running as: {System.Security.Principal.WindowsIdentity.GetCurrent().Name}");

            return true;
        }

        private void LogAppInitialized(bool appInitialized)
        {
            _logger.Info(appInitialized
                ? $"Runtime initialized"
                : $"Runtime initialization failed");
            _logger.Trace("------------------------------------------------------------------------------------------------------");
        }

        private bool InitArea(string areaName, Action<IList<string>> initFunc, string startingVerb = "initializing", string endedVerb = "Initialized")
        {
            _logger.Debug($"{areaName} {startingVerb}...");
            var errorMessages = new List<string>();
            initFunc(errorMessages);
            var success = errorMessages.Count == 0;
            if (success)
                _logger.Debug($"{areaName} {endedVerb}");
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
