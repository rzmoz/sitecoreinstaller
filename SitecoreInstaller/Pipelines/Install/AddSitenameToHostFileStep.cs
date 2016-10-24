using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.Install
{
    public class AddSitenameToHostFileStep : PipelineStep<InstallArgs>
    {
        private readonly HostFile _hostFile;

        public AddSitenameToHostFileStep(HostFile hostFile)
        {
            _hostFile = hostFile;
        }

        protected override Task RunImpAsync(InstallArgs args, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
    }
}
