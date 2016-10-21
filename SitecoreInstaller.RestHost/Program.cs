using System;
using System.Reflection;
using Autofac;
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
        static int Main(string[] args)
        {
            var portNumber = 7919;
            try
            {
                portNumber = int.Parse(args[0]);
            }
            catch (IndexOutOfRangeException) { }

            var runtime = new RuntimeConfigurator();

            var initResult = runtime.Init(ConfigureLog, (c, l) => StartHost(c, l, portNumber),
                builder => builder.RegisterApiControllers(Assembly.GetExecutingAssembly()));

            if (initResult)
            {
                Console.ReadKey();
                return 0;
            }

            Console.WriteLine("Press key to exit");
            Console.ReadKey();
            return 1;
        }

        private static void ConfigureLog(NLogConfigurator logConf)
        {
            logConf.AddTarget(new ColoredConsoleTarget
            {
                Layout = "${message}"
            }.AddLogColor(LogLevel.Debug, ConsoleOutputColor.DarkGray)
                    .AddLogColor(LogLevel.Trace, ConsoleOutputColor.Cyan)
                    .AddLogColor(LogLevel.Info, ConsoleOutputColor.White)
                    .AddLogColor(LogLevel.Warn, ConsoleOutputColor.Yellow)
                    .AddLogColor(LogLevel.Error, ConsoleOutputColor.Red)
                    .AddLogColor(LogLevel.Fatal, ConsoleOutputColor.White, ConsoleOutputColor.DarkRed));

            logConf.AddTarget(new MethodCallTarget
            {
                MethodName = $"{typeof(Program).FullName}, {typeof(Program).Assembly.FullName}"
            }, "*", LogLevel.Fatal);
        }

        private static void StartHost(IContainer container, ILogger logger, int portNumber)
        {
            string baseAddress = $"http://localhost:{portNumber}/";

            // Start OWIN host 
            using (WebApp.Start(baseAddress, appBuilder =>
            {

                var webapiInit = new WebApiInit();
                logger.Debug("Initalizing WebApi...");
                webapiInit.Configuration(appBuilder, container, logger);
                logger.Trace($"WebApi is listening on {baseAddress}");
                logger.Debug("WebApi initialized");
            }));
        }

        public static void LogMethod(string level, string message)
        {
            if (level == LogLevel.Fatal.ToString())
                throw new ApplicationException($"Fatal encouterend: {message}. Aborting...");
        }
    }
}
