﻿using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using DotNet.Basics.NLog;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using NLog;
using NLog.Targets;
using SitecoreInstaller.Pipelines;
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
                iocBuilder.RegisterPipelineSteps(typeof(LocalArgs).Assembly);
                
                var serializer = JsonSerializer.Create(new JsonSerializerSettings { ContractResolver = new SignalRContractResolver() });
                iocBuilder.RegisterInstance(serializer).As<JsonSerializer>();
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
                    var webapiInit = new HostInit();
                    webapiInit.Init(app, runtime.Container);
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

                    Console.WriteLine(@"Press key to quit...");
                    Console.ReadKey();
                    return 0;
                }
            }
            catch (TargetInvocationException e)
            {
                runtime.NLog().Fatal($"Failed to start host: {runtime.HostName}. Aborting: {e}");
                runtime.NLog().Fatal(AsciiArts.FailFace);
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
