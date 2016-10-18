using System;
using DotNet.Basics.NLog;
using NLog;
using NLog.Fluent;
using NLog.Targets;
using SitecoreInstaller.Runtime;

namespace SitecoreInstaller.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var runtime = new RuntimeConfigurator(typeof(Program));
            runtime.Init(logConf =>
            {
                var console = new ColoredConsoleTarget
                {
                    Layout = "${message}"
                };
                console.AddDefaultLogColors();

                logConf.AddTarget(console.AsBuffered());

                var callbackTarget = new MethodCallTarget();
                callbackTarget.MethodName = "SitecoreInstaller.Console.Program, SitecoreInstaller.Console";
                logConf.AddTarget(callbackTarget, "*", LogLevel.Fatal);
            });

            System.Console.ReadKey();
        }
        public static void LogMethod(string level, string message)
        {
            if (level == LogLevel.Fatal.ToString())
                throw new ApplicationException($"Fatal encouterend: {message}. Aborting...");
        }
    }
}
