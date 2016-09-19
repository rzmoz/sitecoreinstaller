using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class AddSitenameToHostfileStep : PipelineStep<InstallArgs>
    {
        protected override Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

    }
}
