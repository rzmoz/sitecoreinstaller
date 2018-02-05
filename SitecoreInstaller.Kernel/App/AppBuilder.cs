using System;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Basics.Autofac;
using DotNet.Basics.Collections;
using DotNet.Basics.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App
{
    public class AppBuilder
    {
        private readonly AutofacBuilder _iocBuilder;

        public AppBuilder(Action<IServiceCollection> configureLogging, Action<AutofacBuilder> iocRegistrations = null, ApplicationSettings applicationSettings = null)
        {
            _iocBuilder = new AutofacBuilder();
            _iocBuilder.AddByServiceCollection(services => configureLogging?.Invoke(services));
            _iocBuilder.AddRegistrations(new SitecoreInstallerRegistrations(applicationSettings ?? new ApplicationSettings()));
            iocRegistrations?.Invoke(_iocBuilder);
            Logger.LogDebug($"Application Inititialization complete");
        }

        public async Task<int> RunAsync(Action<IServiceProvider, ILogger> run = null)
        {
            var preflightsResult = await RunPreflightChecksAsync().ConfigureAwait(false);
            if (preflightsResult.Issues.Any())
            {
                preflightsResult.Issues.ForEach(issue =>
                {
                    Logger.Log(issue.LogLevel, 0, new FormattedLogValues(issue.Message), issue.Exception, (val, error) => val.ToString());
                });
                return preflightsResult.Issues.Count;
            }
            try
            {
                run?.Invoke(_iocBuilder.ServiceProvider, Logger);
                return 0;
            }
            catch (Exception e)
            {
                Logger.LogCritical(e, $"Application failed: {e.ToString()}");
                return -1;
            }
        }

        private async Task<TaskResult> RunPreflightChecksAsync()
        {
            var preflightChecks = _iocBuilder.ServiceProvider.GetServices<IPreflightCheck>().ToList();
            Logger.LogDebug($"Running {preflightChecks.Count} PreflightChecks");
            var taskResult = new TaskResult();
            foreach (var preflightCheck in preflightChecks)
            {
                Logger.LogDebug($"Running PreflightCheck: {preflightCheck.GetType().Name}");
                var checkResult = await preflightCheck.AssertAsync().ConfigureAwait(false);
                taskResult = taskResult.Append(list => list.AddRange(checkResult.Issues));
                Logger.LogDebug($"PreflightCheck {preflightCheck.GetType().Name} success {taskResult.Issues.None()}: Issues:{taskResult.Issues}");
            }

            Logger.LogDebug($"PreflightChecks complete with {taskResult.Issues.Count} issues");
            return taskResult;
        }

        private ILogger Logger => _iocBuilder.ServiceProvider.GetService<ILogger<AppBuilder>>();
    }
}
