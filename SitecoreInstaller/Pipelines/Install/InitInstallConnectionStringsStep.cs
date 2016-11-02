using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitInstallConnectionStringsStep : PipelineStep<LocalInstallArgs>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;
        private readonly ConnectionStringsConfigFormatter _connectionStringsConfigFormatter;

        public InitInstallConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory, ConnectionStringsConfigFormatter connectionStringsConfigFormatter)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
            _connectionStringsConfigFormatter = connectionStringsConfigFormatter;
        }
        
        protected override Task RunImpAsync(LocalInstallArgs args, CancellationToken ct)
        {
            var existing = _dbConnectionStringsFactory.Create(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();
            var databaseFilePairs = _dbConnectionStringsFactory.Create(args.Name, args.DeploymentDir.Databases).ToList();

            var mergedConnectionStrings =
                _dbConnectionStringsFactory.MergeWithDatabaseFilePairs(args.Name, existing, databaseFilePairs).ToList();

            args.ConnectionStrings = mergedConnectionStrings;
            args.SqlDatabaseFiles = databaseFilePairs;

            //write connectionstrings to connectionstrings.config
            var connectionStringsDotConfigContent = _connectionStringsConfigFormatter.ToConfigFileString(args.ConnectionStrings);
            connectionStringsDotConfigContent.WriteAllText(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig, overwrite: true);

            return Task.CompletedTask;
        }
    }
}
