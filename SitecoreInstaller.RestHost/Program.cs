using System;
using System.Reflection;
using Autofac.Integration.WebApi;
using DotNet.Basics.NLog;
using Microsoft.Owin.Hosting;
using NLog;
using NLog.Targets;
using SitecoreInstaller.Runtime;

namespace SitecoreInstaller.RestHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var appName = typeof(Program).Namespace;

            var runtime = new RuntimeConfigurator(typeof(Program));
            var logger = LogManager.GetLogger(appName);
            runtime.Init(logConf =>
                {
                    var console = new ColoredConsoleTarget
                    {
                        Layout = "${message}"
                    };
                    console.AddDefaultLogColors();

                    logConf.AddTarget(console.AsBuffered());

                    logConf.AddTarget(new MethodCallTarget
                    {
                        MethodName = $"{typeof(Program).FullName}, {typeof(Program).Assembly.FullName}"
                    }, "*", LogLevel.Fatal);
                }, builder => builder.RegisterApiControllers(Assembly.GetExecutingAssembly()));

            var portNumber = 7919;
            try
            {
                portNumber = int.Parse(args[0]);
            }
            catch (IndexOutOfRangeException)
            {
            }

            logger.Info($"Starting {runtime.AppName} on port {portNumber}...");

            string baseAddress = $"http://localhost:{portNumber}/";

            // Start OWIN host 
            using (WebApp.Start(baseAddress, appBuilder =>
            {
                var webapiInit = new WebApiInit();
                webapiInit.Configuration(appBuilder, runtime, logger);
            }))
            {
                logger.Info($"{runtime.AppName} is listening...");
                Console.ReadKey();
            }
        }

        public static void LogMethod(string level, string message)
        {
            if (level == LogLevel.Fatal.ToString())
                throw new ApplicationException($"Fatal encouterend: {message}. Aborting...");
        }
    }
}
