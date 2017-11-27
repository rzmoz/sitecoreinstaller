using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
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

            Console.ReadKey();
            return 0;

            /*
            //starting host
            var runtime = new RuntimeConfigurator();

            var initialized = runtime.Init(ConfigureLog, iocBuilder =>
            {
                iocBuilder.Register(c => new SiPageRenderer(@".\client".ToDir(), "layout", "404")).AsSelf().As<IPreflightCheck>().SingleInstance();
                iocBuilder.RegisterApiControllers(typeof(Program).Assembly);
                iocBuilder.RegisterPipelineSteps<LocalArgs>();
            });

            if (initialized == false)
            {
                runtime.NLog().Fatal(@"    Runtime failed to inititialize. Aborting...    ");
                runtime.NLog().Fatal(AsciiArts.FailFace);
                Console.ReadKey();
                return 1;
            }

            try
            {
                runtime.NLog().Debug($"Host: {runtime.HostName} starting...");
                var baseAddress = args.Take(1).FirstOrDefault() ?? "http://localhost:7919";

                // Start OWIN host 
                using (WebApp.Start(baseAddress, app =>
                {
                    app.InitWebApi(runtime.Container);
                    app.InitFileServer();
                }))
                {
                    runtime.NLog().Info($"Host: {runtime.HostName} started");
                    runtime.NLog().Trace($"Host is listening on {baseAddress}");

                    //if web client should be started
                    if (args.Any(a => a.EndsWith("noclient", StringComparison.InvariantCultureIgnoreCase)))
                        runtime.NLog().Info($"NoClient switch enabled. Open this url in browser to open client manually: {baseAddress}");
                    else
                    {
                        runtime.NLog().Info($"Opening client on {baseAddress}");
                        CommandPrompt.Run($"start {baseAddress}");
                    }

                    Console.WriteLine(@"Press CTRL+C to quit...");
                    while (true)
                    {
                        //listen
                    }
                }
            }
            catch (TargetInvocationException e)
            {
                runtime.NLog().Fatal($"Failed to start host: {runtime.HostName}. Aborting: {e}");
                runtime.NLog().Fatal(AsciiArts.FailFace);
                Console.ReadKey();
                return 1;
            }*/

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
