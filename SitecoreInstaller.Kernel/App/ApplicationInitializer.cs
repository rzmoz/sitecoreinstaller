using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DotNet.Basics.Autofac;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App
{
    public class ApplicationInitializer
    {
        private readonly ILogger _log;

        public ApplicationInitializer(ILogger<ApplicationInitializer> logger)
        {
            _log = logger;
        }

        public IContainer Container { get; private set; }

        public bool InitRegistrations(ApplicationSettings applicationSettings, Action<AutofacBuilder> iocRegistrations = null)
        {
            return InitArea("IocContainer", errorMsgs =>
            {
                try
                {
                    var builder = new AutofacBuilder(false);
                    builder.AddRegistrations(new SitecoreInstallerRegistrations(applicationSettings));
                    iocRegistrations?.Invoke(builder);
                    Container = builder.Container;
                    foreach (var registration in Container.ComponentRegistry.Registrations)
                        _log?.LogDebug($"{JsonConvert.SerializeObject(registration.Services.Select(s => s.Description)) }");
                }
                catch (Exception e)
                {
                    errorMsgs.Add(e.ToString());
                }
            });
        }

        public async Task InitApplication()
        {
            var applicationInitializers = Container.Resolve<IEnumerable<IPreflightCheck>>();

            foreach (var applicationInitializer in applicationInitializers)
            {
                var result = await applicationInitializer.AssertAsync().ConfigureAwait(false);
                foreach (var issue in result.Issues)
                {
                    _log.LogCritical(issue.Exception, issue.Message);
                }
            }
        }

        private bool InitArea(string areaName, Action<IList<string>> initFunc, string startingVerb = "initializing", string endedVerb = "Initialized")
        {
            _log?.LogDebug($"{areaName} {startingVerb}...");
            var errorMessages = new List<string>();
            initFunc(errorMessages);
            var success = errorMessages.Count == 0;
            if (success)
                _log?.LogDebug($"{areaName} {endedVerb}");
            else
            {
                foreach (var errorMessage in errorMessages)
                    _log?.LogError(errorMessage);

                _log?.LogCritical($"{startingVerb} of {areaName} failed. Application will not run properly. Aborting...");
            }
            return success;
        }
    }
}
