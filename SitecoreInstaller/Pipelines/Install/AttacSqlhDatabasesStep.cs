using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class AttacSqlhDatabasesStep : PipelineStep<InstallEventArgs>
    {
        private readonly SqlDbService _dbService;

        public AttacSqlhDatabasesStep(SqlDbService dbService)
        {
            _dbService = dbService;
        }

        protected override Task InnerRunAsync(InstallEventArgs args, CancellationToken ct)
        {
            _dbService.AttacSqlhDatabases(args.SqlDatabaseFiles);
            return Task.CompletedTask;
        }
    }
}
