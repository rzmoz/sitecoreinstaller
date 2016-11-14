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
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Runtime
{
    public class RuntimeConfigurator
    {
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
        }

        public string HostName { get; }

        public bool Init(Action<NLogConfigurator> configureLog, Action<IocBuilder> iocRegistrations = null)
        {
            //ensure all low level dotnet.basics events are logged
            DebugOut.Out += this.NLog().Debug;

            var initStatus = InitLogging(configureLog);
            initStatus = initStatus && LogAppInitializing();
            initStatus = initStatus && InitContainer(iocRegistrations);
            initStatus = initStatus && InitAppSettings();

            var environmentSettiongs = Container.Resolve<EnvironmentSettings>();
            var genericPreflightchecks = Container.Resolve<IEnumerable<IPreflightCheck>>();
            initStatus = initStatus && RunPreflightChecks(new IPreflightCheck[] { environmentSettiongs }, genericPreflightchecks.ToArray());

            LogAppInitialized(initStatus);
            return initStatus;
        }

        private bool InitContainer(Action<IocBuilder> iocRegistrations)
        {
            return InitArea("IocContainer", (errorMsgs) =>
            {
                try
                {
                    var builder = new IocBuilder(false);
                    builder.Register(new SitecoreInstallerRegistrations());
                    iocRegistrations?.Invoke(builder);
                    Container = builder.Container;
                    foreach (var registration in Container.ComponentRegistry.Registrations)
                        this.NLog().Debug($"{JsonConvert.SerializeObject(registration.Services.Select(s => s.Description)) }");
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
                    this.NLog().Debug($"Running Preflight check: {appsetting.GetType().Name}");
                    var assert = appsetting.Verify();
                    if (assert == false)
                        errorMsgs.Add($"Required key is not configured: {appsetting.Key}");
                }
            });
        }

        private bool RunPreflightChecks(IPreflightCheck[] initPreflightChecks, params IPreflightCheck[] preflightChecks)
        {
            return InitArea("Preflight checks", (errorMsgs) =>
            {
                foreach (var preflightCheck in initPreflightChecks)
                    AssertPreflightCheck(preflightCheck, errorMsgs);
                foreach (var preflightCheck in preflightChecks)
                    AssertPreflightCheck(preflightCheck, errorMsgs);

            }, "Starting", "Finished");
        }

        private void AssertPreflightCheck(IPreflightCheck preflightCheck, IList<string> errorMsgs)
        {
            this.NLog().Debug($"Preflight check: {preflightCheck.GetType().Name} started..");
            var result = preflightCheck.Assert();
            if (result.IsReady)
                this.NLog().Debug($"Preflight check: {preflightCheck.GetType().Name} finished");
            else
                errorMsgs.Add(
                    $"Preflight check {preflightCheck.GetType().Name} failed:\r\n{JsonConvert.SerializeObject(result.Issues)}");
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
            this.NLog().Trace(AsciiArts.Logo);
            this.NLog().Debug($"Runtime initializing...");
            this.NLog().Trace($"UTC Time: {DateTime.UtcNow}");
            this.NLog().Trace($"Host Version: {FileVersionInfo.GetVersionInfo(typeof(RuntimeConfigurator).Assembly.Location).FileVersion}");
            this.NLog().Trace($"Running as: {System.Security.Principal.WindowsIdentity.GetCurrent().Name}");

            return true;
        }

        private void LogAppInitialized(bool appInitialized)
        {
            this.NLog().Info(appInitialized
                ? $"Runtime initialized"
                : $"Runtime initialization failed");
            this.NLog().Trace("------------------------------------------------------------------------------------------------------");
        }

        private bool InitArea(string areaName, Action<IList<string>> initFunc, string startingVerb = "initializing", string endedVerb = "Initialized")
        {
            this.NLog().Debug($"{areaName} {startingVerb}...");
            var errorMessages = new List<string>();
            initFunc(errorMessages);
            var success = errorMessages.Count == 0;
            if (success)
                this.NLog().Debug($"{areaName} {endedVerb}");
            else
            {
                foreach (var errorMessage in errorMessages)
                    this.NLog().Error(errorMessage);

                this.NLog().Fatal($"{startingVerb} of {areaName} failed. Application will not run properly. Aborting...");
            }
            return success;
        }
    }
}
