using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class CreateIisWebsiteStep : PipelineStep<InstallArgs>
    {
        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
