using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{
    public class InitUnInstallConnectionStringsStep : PipelineStep<UnInstallLocalArgs>
    {
        private readonly DbConnectionStringsFactory _dbConnectionStringsFactory;

        public InitUnInstallConnectionStringsStep(DbConnectionStringsFactory dbConnectionStringsFactory)
        {
            _dbConnectionStringsFactory = dbConnectionStringsFactory;
        }
        
        protected override Task RunImpAsync(UnInstallLocalArgs args, CancellationToken ct)
        {
            args.ConnectionStrings = _dbConnectionStringsFactory.Create(args.DeploymentDir.Website.App_Config.ConnectionStringsConfig).ToList();

            return Task.CompletedTask;
        }
    }
}
