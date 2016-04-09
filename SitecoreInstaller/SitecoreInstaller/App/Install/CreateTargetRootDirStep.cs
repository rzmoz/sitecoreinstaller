using System.Security.AccessControl;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class CreateTargetRootDirStep : TaskStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            args.TargetRootDir.CreateIfNotExists();
            args.TargetRootDir.GrantAccess("everyone",FileSystemRights.FullControl);
        }
    }
}
