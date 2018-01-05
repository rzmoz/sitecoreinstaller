using System.Threading.Tasks;
using DotNet.Standard.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SitecoreInstaller.App;

namespace SitecoreInstaller.Host
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            if (args.Length > 0)
                return await RunWebHost(args).ConfigureAwait(false);
            else
                return await RunCli(args).ConfigureAwait(false);
        }

        public static async Task<int> RunWebHost(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(o => o.AddServerHeader = false)
                .UseUrls("http://0.0.0.0:13371")
                .UseStartup<Startup>()
                .Build();

            await host.RunAsync().ConfigureAwait(false);
            return 0;
        }

        public static async Task<int> RunCli(string[] args)
        {
            var app = new AppBuilder(services =>
            {
                services.AddNLogging();
            });

            return await app.RunAsync((provider, logger) =>
            {
                var anonymousLogger = provider.GetService<ILogger>();
                anonymousLogger.LogDebug("Test");

                logger.LogInformation(AsciiArts.Logo);
            }).ConfigureAwait(false);
        }
    }
}
