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
        static int Main(string[] args)
        {
            var hostName = typeof(Program).Namespace;

            var runtime = new RuntimeConfigurator(typeof(Program));
            var logger = LogManager.GetLogger(hostName);
            var initResult = runtime.Init(logConf =>
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
                  }, builder => builder.RegisterApiControllers(Assembly.GetExecutingAssembly()));
            if (initResult == false)
            {
                Console.WriteLine($"Press key to exit");
                Console.ReadKey();
                return 1;
            }



            var portNumber = 7919;
            try
            {
                portNumber = int.Parse(args[0]);
            }
            catch (IndexOutOfRangeException)
            {
            }

            logger.Debug($"{hostName} starting...");

            string baseAddress = $"http://localhost:{portNumber}/";

            // Start OWIN host 
            using (WebApp.Start(baseAddress, appBuilder =>
            {
                var webapiInit = new WebApiInit();
                webapiInit.Configuration(appBuilder, runtime, logger);
            }))
            {
                logger.Trace($"{hostName} is listening on {baseAddress}");
                logger.Info($"{hostName} started");

                Console.ReadKey();
                return 0;
            }
        }

        public static void LogMethod(string level, string message)
        {
            if (level == LogLevel.Fatal.ToString())
                throw new ApplicationException($"Fatal encouterend: {message}. Aborting...");
        }
    }
}
