using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class InstallLocalSuccessStep<T> : PipelineStep<T> where T : LocalArgs, new()
    {
        protected override Task RunImpAsync(T args, CancellationToken ct)
        {
            args.Info.Task.Status = DeploymentStatus.Success;
            args.DeploymentDir.SaveDeploymentInfo(args.Info);

            return Task.CompletedTask;
        }
    }
}
