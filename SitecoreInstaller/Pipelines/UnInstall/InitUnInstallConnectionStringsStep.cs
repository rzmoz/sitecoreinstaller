using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class InitUnInstallConnectionStringsStep : PipelineStep<UnInstallArgs>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;

        public InitUnInstallConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
        }

        protected override Task InnerRunAsync(UnInstallArgs args, CancellationToken ct)
        {
            args.ConnectionStrings = _dbConnectionStringsFactory.Create(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();

            return Task.CompletedTask;
        }
    }
}
