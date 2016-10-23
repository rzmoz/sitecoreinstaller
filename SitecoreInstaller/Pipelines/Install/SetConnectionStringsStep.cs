using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class SetConnectionStringsStep : PipelineStep<EventArgs<DeploymentSettings>>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;
        private readonly ConnectionStringsConfigFormatter _connectionStringsConfigFormatter;
        public SetConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory, ConnectionStringsConfigFormatter connectionStringsConfigFormatter)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
            _connectionStringsConfigFormatter = connectionStringsConfigFormatter;
        }

        protected override Task InnerRunAsync(EventArgs<DeploymentSettings> args, CancellationToken ct)
        {
            var existing = _dbConnectionStringsFactory.Create(args.Value.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();
            var fromDatabaseFiles = _dbConnectionStringsFactory.Create(args.Value.Name, args.Value.DeploymentDir.Databases).ToList();

            var updatedEntries = _dbConnectionStringsFactory.Create(args.Value.Name, existing, fromDatabaseFiles);
            
            var connectionStringsDotConfigContent = _connectionStringsConfigFormatter.ToConfigFileString(updatedEntries);
            connectionStringsDotConfigContent.WriteAllText(args.Value.DeploymentDir.Website.App_Config.ConnectionStringsConfig);
            return Task.CompletedTask;
        }
    }
}
