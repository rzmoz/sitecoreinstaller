using System.Diagnostics;
using System.Threading.Tasks;
using DotNet.Standard.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SitecoreInstaller.App;

namespace SitecoreInstaller.Host
{
    public class Program
    {
        private const string _cliHelpTemplate = "-?|-h|--help";

        public static int Main(string[] args)
        {
            var app = new CommandLineApplication(false)
            {
                Name = "SitecoreInstaller",
                FullName = "SitecoreInstaller",
                Description = "SitecoreInstaller for fast and easy installation of Sitecore"
            };
            app.HelpOption(_cliHelpTemplate);
            app.VersionOption("-v|--version", GetVersions().ShortVersion, GetVersions().LongVersion);

            app.Command("ui", conf =>
            {
                conf.Description = "Run SitecoreInstaller with full UI";
                conf.HelpOption(_cliHelpTemplate);
                conf.OnExecute(async () => await RunWebHostAsync().ConfigureAwait(false));
            });

            app.Command("console", conf =>
            {
                conf.Description = "Run SitecoreInstaller with cli";
                conf.HelpOption(_cliHelpTemplate);
                conf.OnExecute(async () => await RunConsoleAsync().ConfigureAwait(false));
            });

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 0;
            });

            return app.Execute(args);
        }

        private static (string ShortVersion, string LongVersion) GetVersions()
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(typeof(Program).Assembly.Location);
            return (fileVersionInfo.FileVersion, fileVersionInfo.ProductVersion);
        }

        public static async Task<int> RunWebHostAsync()
        {
            var host = new WebHostBuilder()
                .UseKestrel(o => o.AddServerHeader = false)
                .UseUrls("http://0.0.0.0:13371")
                .UseStartup<Startup>()
                .Build();

            await host.RunAsync().ConfigureAwait(false);
            return 0;
        }

        public static async Task<int> RunConsoleAsync()
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
