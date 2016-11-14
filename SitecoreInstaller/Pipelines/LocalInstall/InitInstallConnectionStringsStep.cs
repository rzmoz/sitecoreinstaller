using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class InitInstallConnectionStringsStep : PipelineStep<InstallLocalArgs>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;
        private readonly ConnectionStringsConfigFormatter _connectionStringsConfigFormatter;

        public InitInstallConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory, ConnectionStringsConfigFormatter connectionStringsConfigFormatter)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
            _connectionStringsConfigFormatter = connectionStringsConfigFormatter;
        }
        
        protected override Task RunImpAsync(InstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            var existing = _dbConnectionStringsFactory.Create(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();
            var databaseFilePairs = _dbConnectionStringsFactory.Create(args.Info.Name, args.DeploymentDir.Databases).ToList();

            var mergedConnectionStrings =
                _dbConnectionStringsFactory.MergeWithDatabaseFilePairs(args.Info.Name, existing, databaseFilePairs).ToList();

            args.ConnectionStrings = mergedConnectionStrings;
            args.SqlDatabaseFiles = databaseFilePairs;

            //write connectionstrings to connectionstrings.config
            var connectionStringsDotConfigContent = _connectionStringsConfigFormatter.ToConfigFileString(args.ConnectionStrings);
            connectionStringsDotConfigContent.WriteAllText(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig, overwrite: true);

            return Task.CompletedTask;
        }
    }
}
