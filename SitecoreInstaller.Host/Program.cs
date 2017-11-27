using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using DotNet.Basics.Cli;
using DotNet.Basics.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Owin.Hosting;
using SitecoreInstaller.Host.ClientControllers;
using SitecoreInstaller.Kernel;

namespace SitecoreInstaller.Host
{
    class Program
    {
        static int Main(string[] args)
        {
            var hostInit = new HostInit(() =>
            {
                return new ConsoleLogger(typeof(HostInit).FullName, (s, level) => true, false);
            });

            hostInit.Logger.LogInformation(AsciiArts.Logo);

            hostInit.ConfigureServices(builder =>
            {
                builder.Register(c => new SiPageRenderer(@".\client".ToDir(), "layout", "404")).AsSelf().SingleInstance();
                builder.RegisterApiControllers(typeof(ClientController).Assembly);
                new SiRegistrations().RegisterIn(builder);
            });

            try
            {
                hostInit.Logger.LogDebug($"Host  starting...");
                var baseAddress = args.Take(1).FirstOrDefault() ?? "http://localhost:7919";

                // Start OWIN host 
                using (WebApp.Start(baseAddress, app =>
                {
                    hostInit.UseFileServer(app);
                    hostInit.UseWebApi(app);
                }))
                {
                    hostInit.Logger.LogDebug($"Host started");
                    hostInit.Logger.LogTrace($"Host is listening on {baseAddress}");

                    //if web client should be started
                    if (args.Any(a => a.EndsWith("noclient", StringComparison.InvariantCultureIgnoreCase)))
                        hostInit.Logger.LogInformation($"NoClient switch enabled. Open this url in browser to open client manually: {baseAddress}");
                    else
                    {
                        hostInit.Logger.LogInformation($"Opening client on {baseAddress}");
                        CommandPrompt.Run($"start {baseAddress}");
                    }

                    Console.WriteLine(@"Press CTRL+C to quit...");
                    Console.ReadKey();
                    return 0;
                }
            }
            catch (TargetInvocationException e)
            {
                hostInit.Logger.LogCritical($"Failed to start host. Aborting: {e}");
                hostInit.Logger.LogCritical(AsciiArts.FailFace);
                Console.ReadKey();
                return 1;
            }
        }
        /*
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
        }*/
    }
}
