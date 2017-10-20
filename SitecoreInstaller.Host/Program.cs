using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using DotNet.Basics.Cli;
using DotNet.Basics.IO;
using DotNet.Basics.NLog;
using Microsoft.Owin.Hosting;
using NLog;
using SitecoreInstaller.App;

namespace SitecoreInstaller.Host
{
    public class Program
    {
        static int Main(string[] args)
        {
            //init host
            var hostInit = new HostInit();
            var appInit = new ApplicationInitializer();

            hostInit.InitLogging();
            hostInit.LogHostBoot();

            appInit.InitRegistrations(iocBuilder =>
            {
                iocBuilder.Register(c => new SiPageRenderer(@".\wwwroot".ToDir(), "layout", "404")).AsSelf().SingleInstance();
                iocBuilder.RegisterApiControllers(typeof(Program).Assembly);
            });

            appInit.InitApplication();
            appInit.RunPreflightChecks();

            try
            {
                hostInit.NLog().Debug($"Host: {hostInit.HostName} starting...");
                var baseAddress = args.Take(1).FirstOrDefault() ?? "http://localhost:13375";

                // Start OWIN host 
                using (WebApp.Start(baseAddress, app =>
                {
                    hostInit.InitWebApi(app, appInit.Container);
                    hostInit.InitFileServer(app);
                }))
                {
                    hostInit.NLog().Debug($"Host: {hostInit.HostName} started");
                    hostInit.NLog().Trace($"Host is listening on {baseAddress}");

                    //if web client should be started
                    if (args.Any(a => a.EndsWith("noclient", StringComparison.InvariantCultureIgnoreCase)))
                        hostInit.NLog().Info($"NoClient switch enabled. Open this url in browser to open client manually: {baseAddress}");
                    else
                    {
                        hostInit.NLog().Debug($"Opening client in browser...");
                        CommandPrompt.Run($"start {baseAddress}");
                    }

                    Console.WriteLine(@"Press CTRL+C to quit...");
                    Console.ReadLine();
                    return 0;
                }
            }
            catch (TargetInvocationException e)
            {
                hostInit.NLog().Fatal($"Failed to start host: {hostInit.HostName}. Aborting: {e}");
                hostInit.NLog().Fatal(AsciiArts.FailFace);
                Console.ReadKey();
                return -1;
            }
        }

        public static void LogMethod(string level, string message)
        {
            if (level == LogLevel.Fatal.ToString())
                throw new ApplicationException($"Fatal encouterend: {message}. Aborting...");
        }
    }
}
