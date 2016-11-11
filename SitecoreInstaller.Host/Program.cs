using System;
using System.Linq;
using System.Reflection;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using DotNet.Basics.NLog;
using DotNet.Basics.Sys;
using Microsoft.Owin.Hosting;
using NLog;
using NLog.Targets;
using SitecoreInstaller.Runtime;

namespace SitecoreInstaller.Host
{
    class Program
    {
        static int Main(string[] args)
        {
            //starting host
            var runtime = new RuntimeConfigurator();

            var initialized = runtime.Init(ConfigureLog, iocBuilder =>
            {
                iocBuilder.RegisterApiControllers(typeof(Program).Assembly);
                iocBuilder.RegisterHubs(typeof(Program).Assembly);
            });

            if (initialized == false)
            {
                runtime.Logger.Fatal(@"    Runtime failed to inititialize. Aborting...    ");
                runtime.Logger.Fatal(AsciiArts.FailFace);
                Console.ReadKey();
                return 1;
            }

            try
            {
                runtime.Logger.Debug($"Host: {runtime.HostName} starting...");
                var baseAddress = args.Take(1).FirstOrDefault() ?? "http://localhost:7919";

                // Start OWIN host 
                using (WebApp.Start(baseAddress, app =>
                {
                    var webapiInit = new HostInit();
                    webapiInit.Init(app, runtime.Container, runtime.Logger);
                }))
                {
                    runtime.Logger.Info($"Host: {runtime.HostName} started");
                    runtime.Logger.Trace($"Host is listening on {baseAddress}");

                    //if web client should be started
                    if (args.Any(a => a.EndsWith("noclient", StringComparison.InvariantCultureIgnoreCase)))
                        runtime.Logger.Info($"NoClient switch enabled. Open this url in browser to open client manually: {baseAddress}");
                    else
                    {
                        runtime.Logger.Info($"Opening client on {baseAddress}");
                        CommandPrompt.Run($"start {baseAddress}");
                    }

                    Console.WriteLine(@"Press key to quit...");
                    Console.ReadKey();
                    return 0;
                }
            }
            catch (TargetInvocationException e)
            {
                runtime.Logger.Fatal($"Failed to start host: {runtime.HostName}. Aborting: {e}");
                Console.ReadKey();
                return 1;
            }
        }

        private static void ConfigureLog(NLogConfigurator logConf)
        {
            logConf.AddTarget(new ColoredConsoleTarget
            {
                Layout = "${message}"
            }.WithOutputColors());

            logConf.AddTarget(new MethodCallTarget
            {
                MethodName = $"{typeof(Program).FullName}, {typeof(Program).Assembly.FullName}"
            }, "*", LogLevel.Fatal);
        }

        public static void LogMethod(string level, string message)
        {
            if (level == LogLevel.Fatal.ToString())
                throw new ApplicationException($"Fatal encouterend: {message}. Aborting...");
        }
    }
}
