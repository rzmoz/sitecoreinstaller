using System.Security.AccessControl;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class CreateInstallDirStep : TaskStep<InstallArgs>
    {
        public override Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            return Task.Factory.StartNew(() =>
            {
                args.InstallDir.CreateIfNotExists();
                args.InstallDir.GrantAccess("everyone", FileSystemRights.FullControl);
            });
        }
    }
}
