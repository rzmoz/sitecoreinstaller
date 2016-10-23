using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.Install
{
    public class SetConnectionStringsStep : PipelineStep<EventArgs<DeploymentSettings>>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;

        public SetConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
        }

        protected override Task InnerRunAsync(EventArgs<DeploymentSettings> args, CancellationToken ct)
        {
            var existing = _dbConnectionStringsFactory.Create(args.Value.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();
            var fromDatabaseFiles = _dbConnectionStringsFactory.Create(args.Value.DeploymentDir.Databases).ToList();

            return Task.CompletedTask;
        }
    }
}
