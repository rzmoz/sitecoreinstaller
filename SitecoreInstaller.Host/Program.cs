using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;

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
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(context.HostingEnvironment.ContentRootPath);
                    if (args != null)
                        config.AddCommandLine(args);
                    config.AddEnvironmentVariables();
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                })
                .ConfigureLogging((context, logging) =>
                {



                    logging.AddNLog();
                })
                .UseUrls(cliArgs["server.urls"] ?? "http://0.0.0.0:13375")
                .ConfigureServices((context, options) => {/**/})
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
