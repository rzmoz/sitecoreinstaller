using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class CreateInstallDirStep : PipelineStep<InstallArgs>
    {
        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            args.InstallDir.CreateIfNotExists();
            args.InstallDir.GrantAccess("everyone", FileSystemRights.FullControl);
        }
    }
}
