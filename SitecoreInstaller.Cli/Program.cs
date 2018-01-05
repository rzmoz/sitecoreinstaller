using System.Threading.Tasks;
using DotNet.Standard.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SitecoreInstaller.App;

namespace SitecoreInstaller.Cli
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var app = new ApplicationBuilder(services =>
                {
                    services.AddNLogging();
                });

            return await app.Start((provider, logger) =>
            {
                var anonymousLogger = provider.GetService<ILogger>();
                anonymousLogger.LogDebug("Test");

                logger.LogInformation(AsciiArts.Logo);
            }).ConfigureAwait(false);
        }
    }
}