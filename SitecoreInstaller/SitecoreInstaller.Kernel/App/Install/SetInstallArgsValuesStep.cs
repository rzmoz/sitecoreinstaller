using System;
using System.Threading.Tasks;
using CSharp.Basics.Diagnostics;
using CSharp.Basics.Pipelines;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class SetInstallArgsValuesStep : TaskStep<InstallArgs>
    {
        public override Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            throw new NotImplementedException();
        }
    }
}
