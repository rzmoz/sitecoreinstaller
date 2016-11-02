using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class AttachSqlhDatabasesStep : PipelineStep<LocalInstallArgs>
    {
        private readonly SqlDbService _dbService;

        public AttachSqlhDatabasesStep(SqlDbService dbService)
        {
            _dbService = dbService;
        }

        protected override Task RunImpAsync(LocalInstallArgs args, CancellationToken ct)
        {
            _dbService.AttacSqlhDatabases(args.SqlDatabaseFiles);
            return Task.CompletedTask;
        }
    }
}
