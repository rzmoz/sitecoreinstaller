using System.Threading.Tasks;
using CSharp.Basics.Diagnostics;
using CSharp.Basics.IO;
using CSharp.Basics.Pipelines;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class CreateTargetInstallDirStep : TaskStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            args.TargetRootDir.CreateIfNotExists();
            args.TargetRootDir.GrantFullControl("everyone");
        }
    }
}
