using System.IO;
using NLog.Targets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using DotNet.Basics.Extensions.NLog;

namespace SitecoreInstaller.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cliArgs = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            
            var host = new WebHostBuilder()
                .UseKestrel(o=> {
                    o.AddServerHeader = false;
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    if (args != null)
                        config.AddCommandLine(args);
                    config.AddEnvironmentVariables();
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddNLog(conf =>
                    {
                        conf.AddTarget(new ColoredConsoleTarget().WithOutputColors());
                    });
                })
                .UseUrls(cliArgs["server.urls"] ?? "http://0.0.0.0:13375")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
