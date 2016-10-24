using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitConnectionStringsStep : PipelineStep<InstallEventArgs>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;
        private readonly ConnectionStringsConfigFormatter _connectionStringsConfigFormatter;

        public InitConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory, ConnectionStringsConfigFormatter connectionStringsConfigFormatter)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
            _connectionStringsConfigFormatter = connectionStringsConfigFormatter;
        }

        protected override Task InnerRunAsync(InstallEventArgs args, CancellationToken ct)
        {
            var existing = _dbConnectionStringsFactory.Create(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();
            var databaseFilePairs = _dbConnectionStringsFactory.Create(args.Name, args.DeploymentDir.Databases).ToList();

            //write connection string sto connectionstrings.config
            var connectionStringsDotConfigContent = _connectionStringsConfigFormatter.ToConfigFileString(existing);
            connectionStringsDotConfigContent.WriteAllText(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig);

            //set connectionstrings in args
            args.ConnectionStrings = _dbConnectionStringsFactory.MergeWithDatabaseFilePairs(args.Name, existing, databaseFilePairs).ToList();
            args.SqlDatabaseFiles = databaseFilePairs;

            return Task.CompletedTask;
        }
    }
}
