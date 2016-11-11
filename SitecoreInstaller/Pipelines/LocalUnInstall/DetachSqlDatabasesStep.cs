using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{
    public class DetachSqlDatabasesStep : PipelineStep<UnInstallLocalArgs>
    {
        private readonly SqlDbService _dbService;

        public DetachSqlDatabasesStep(SqlDbService dbService)
        {
            _dbService = dbService;
        }
        
        protected override Task RunImpAsync(UnInstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            _dbService.DetachDatabases(args.ConnectionStrings.OfType<SqlDbConnectionString>());
            return Task.CompletedTask;
        }
    }
}
