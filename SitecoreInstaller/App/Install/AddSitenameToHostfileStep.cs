using System;
using System.Threading.Tasks;
using DotNet.Basics.Pipelines;
using Microsoft.Extensions.Logging;

namespace SitecoreInstaller.App.Install
{
    public class AddSitenameToHostfileStep : PipelineStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
