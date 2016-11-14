using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{/*
    public class DropMongoDatabasesStep : PipelineStep<UnInstallLocalArgs>
    {
        private readonly MongoDbService _dbService;

        public DropMongoDatabasesStep(MongoDbService dbService)
        {
            _dbService = dbService;
        }

        protected override Task RunImpAsync(UnInstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            _dbService.DropCollections(args.ConnectionStrings.OfType<MongoDbConnectionString>());
            return Task.CompletedTask;
        }
    }*/
}
