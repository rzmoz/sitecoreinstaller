using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InitInstallConnectionStringsStep : PipelineStep<InstallArgs>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;

        public InitInstallConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
        }

        protected override Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            var existing = _dbConnectionStringsFactory.Create(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();
            var databaseFilePairs = _dbConnectionStringsFactory.Create(args.Name, args.DeploymentDir.Databases).ToList();

            var mergedConnectionStrings =
                _dbConnectionStringsFactory.MergeWithDatabaseFilePairs(args.Name, existing, databaseFilePairs).ToList();

            args.ConnectionStrings = mergedConnectionStrings;
            args.SqlDatabaseFiles = databaseFilePairs;

            return Task.CompletedTask;
        }
    }
}
