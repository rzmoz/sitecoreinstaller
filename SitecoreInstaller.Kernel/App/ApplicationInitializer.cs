using System;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Standard.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App
{
    public class ApplicationInitializer
    {
        private readonly ILogger<ApplicationInitializer> _logger;

        public ApplicationInitializer(ILogger<ApplicationInitializer> logger)
        {
            _logger = logger;
        }

        public IServiceProvider InitRegistrations(ApplicationSettings applicationSettings, Action<AutofacBuilder> iocRegistrations = null)
        {
            var builder = new AutofacBuilder();

            builder.AddRegistrations(new SitecoreInstallerRegistrations(applicationSettings));
            iocRegistrations?.Invoke(builder);

            foreach (var registration in builder.Container.ComponentRegistry.Registrations)
                _logger?.LogDebug($"{JsonConvert.SerializeObject(registration.Services.Select(s => s.Description)) }");

            return builder.ServiceProvider;
        }

        public async Task RunPreflightChecksAsync(IServiceProvider provider)
        {
            var applicationInitializers = provider.GetServices<IPreflightCheck>();

            foreach (var applicationInitializer in applicationInitializers)
            {
                var result = await applicationInitializer.AssertAsync().ConfigureAwait(false);
                foreach (var issue in result.Issues)
                {
                    _logger.LogCritical(issue.Exception, issue.Message);
                }
            }
        }
    }
}
