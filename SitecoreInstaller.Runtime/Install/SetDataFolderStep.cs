using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.Runtime.Install
{
    public class SetDataFolderStep : PipelineStep<InstallArgs>
    {
        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
