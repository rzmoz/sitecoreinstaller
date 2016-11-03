using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Pipelines.LocalInstall;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class AddSiteToHostFileStep : PipelineStep<InstallLocalArgs>
    {
        private readonly HostFile _hostFile;

        public AddSiteToHostFileStep(HostFile hostFile)
        {
            _hostFile = hostFile;
        }

        protected override Task RunImpAsync(InstallLocalArgs args, CancellationToken ct)
        {
            _hostFile.AddHostName(args.Info.Url);
            return Task.CompletedTask;
        }
    }
}
