using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.Install
{
    public class AddSiteToHostFileStep : PipelineStep<LocalInstallArgs>
    {
        private readonly HostFile _hostFile;

        public AddSiteToHostFileStep(HostFile hostFile)
        {
            _hostFile = hostFile;
        }

        protected override Task RunImpAsync(LocalInstallArgs args, CancellationToken ct)
        {
            _hostFile.AddHostName(args.Name);
            return Task.CompletedTask;
        }
    }
}
