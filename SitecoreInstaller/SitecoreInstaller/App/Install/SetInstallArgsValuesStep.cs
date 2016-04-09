using System;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class SetInstallArgsValuesStep : TaskStep<InstallArgs>
    {
        public override Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            throw new NotImplementedException();
        }
    }
}
