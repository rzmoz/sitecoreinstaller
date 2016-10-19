using System;
using NLog;
using DotNet.Basics.NLog;
using Microsoft.Owin.Hosting;
using NLog.Targets;
using SitecoreInstaller.Runtime;

namespace SitecoreInstaller.RestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var runtime = new RuntimeConfigurator(typeof(Program));
            var logger = LogManager.GetLogger(runtime.AppName);
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
                });

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
            using (WebApp.Start<WebApiInit>(url: baseAddress))
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
