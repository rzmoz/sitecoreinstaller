using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{
    public class DeleteDeploymentDirStep : PipelineStep<UnInstallLocalArgs>
    {
        protected override async Task RunImpAsync(UnInstallLocalArgs args, CancellationToken ct)
        {
            args.WasDeleted = await args.DeploymentDir.DeleteAsync().ConfigureAwait(false);
        }
    }
}
