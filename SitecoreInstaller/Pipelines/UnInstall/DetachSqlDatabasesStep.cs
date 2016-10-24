using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class DetachSqlDatabasesStep : PipelineStep<UnInstallArgs>
    {
        private readonly SqlDbService _dbService;

        public DetachSqlDatabasesStep(SqlDbService dbService)
        {
            _dbService = dbService;
        }
        
        protected override Task RunImpAsync(UnInstallArgs args, CancellationToken ct)
        {
            _dbService.DetachDatabases(args.ConnectionStrings.OfType<SqlDbConnectionString>());
            return Task.CompletedTask;
        }
    }
}
