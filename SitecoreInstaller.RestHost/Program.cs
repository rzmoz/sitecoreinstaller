using System;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Reflection;
using Autofac.Integration.WebApi;
using DotNet.Basics.NLog;
using DotNet.Basics.Sys;
using Microsoft.Owin.Hosting;
using NLog;
using NLog.Targets;
using SitecoreInstaller.Runtime;

namespace SitecoreInstaller.RestHost
{
    class Program
    {
        static int Main(string[] args)
        {
            //starting host
            var runtime = new RuntimeConfigurator();

            if (runtime.Init(ConfigureLog, builder => builder.RegisterApiControllers(typeof(Program).Assembly)) == false)
            {
                runtime.Logger.Fatal($"Runtime failed to inititialize. Aborting...");
                Console.ReadKey();
                return 1;
            }

            // Start OWIN host 
            IDisposable host = null;
            try
            {
                runtime.Logger.Debug($"Host: {runtime.HostName} starting...");
                var portNumber = int.Parse(args.Take(1).FirstOrDefault() ?? "7919");
                string baseAddress = $"http://localhost:{portNumber}/";

                host = WebApp.Start(baseAddress, appBuilder =>
                {
                    var webapiInit = new WebApiInit();
                    webapiInit.Init(appBuilder, runtime.Container, runtime.Logger);
                });
                runtime.Logger.Trace($"WebApi is listening on {baseAddress}");
                runtime.Logger.Info($"Host: {runtime.HostName} started");
                Console.WriteLine(@"Press key to quit...");
                CommandPrompt.Run($"start {baseAddress}");
                Console.ReadKey();
                return 0;
            }
            catch (TargetInvocationException e)
            {
                runtime.Logger.Fatal($"Failed to start host: {runtime.HostName}. Aborting: {e}");
                Console.ReadKey();
                return 1;
            }
            finally
            {
                host?.Dispose();
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
