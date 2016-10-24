using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class DropMongoDatabasesStep : PipelineStep<UnInstallArgs>
    {
        private readonly MongoDbService _dbService;

        public DropMongoDatabasesStep(MongoDbService dbService)
        {
            _dbService = dbService;
        }

        protected override Task RunImpAsync(UnInstallArgs args, CancellationToken ct)
        {
            _dbService.DropCollections(args.ConnectionStrings.OfType<MongoDbConnectionString>());
            return Task.CompletedTask;
        }
    }
}
