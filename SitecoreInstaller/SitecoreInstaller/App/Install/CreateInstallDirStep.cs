using System.Security.AccessControl;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class CreateInstallDirStep : TaskStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            args.InstallDir.CreateIfNotExists();
            args.InstallDir.GrantAccess("everyone",FileSystemRights.FullControl);
        }
    }
}
