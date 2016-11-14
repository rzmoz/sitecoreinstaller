using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.LocalUnInstall
{/*
    public class RemoveSiteFromHostFileStep : PipelineStep<UnInstallLocalArgs>
    {
        private readonly HostFile _hostFile;

        public RemoveSiteFromHostFileStep(HostFile hostFile)
        {
            _hostFile = hostFile;
        }

        protected override Task RunImpAsync(UnInstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            _hostFile.RemoveHostName(args.Info.Url);

            return Task.CompletedTask;
        }
    }*/
}
