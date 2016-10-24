using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class WriteUpdatedConnectionStringsToConnectionStringsConfigStep : PipelineStep<InstallArgs>
    {
        private readonly ConnectionStringsConfigFormatter _connectionStringsConfigFormatter;

        public WriteUpdatedConnectionStringsToConnectionStringsConfigStep(ConnectionStringsConfigFormatter connectionStringsConfigFormatter)
        {
            _connectionStringsConfigFormatter = connectionStringsConfigFormatter;
        }

        protected override Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            //write connectionstrings to connectionstrings.config
            var connectionStringsDotConfigContent = _connectionStringsConfigFormatter.ToConfigFileString(args.ConnectionStrings);
            connectionStringsDotConfigContent.WriteAllText(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig, overwrite: true);

            return Task.CompletedTask;
        }
    }
}
