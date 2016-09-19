using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.RuntimeServices;

namespace SitecoreInstaller.Runtime.Install
{
    public class CopyRuntimeServicesStep : PipelineStep<InstallArgs>
    {
        private readonly RuntimeServicesProvider _runtimeServicesProvider;

        public CopyRuntimeServicesStep(RuntimeServicesProvider runtimeServicesProvider) : base(null)
        {
            _runtimeServicesProvider = runtimeServicesProvider;
        }

        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            await _runtimeServicesProvider.InstallRuntimeServicesAsync(args.WebsiteRoot).ConfigureAwait(false);
        }
    }
}
