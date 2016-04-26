using System.Security.AccessControl;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using Microsoft.Extensions.Logging;

namespace SitecoreInstaller.App.Install
{
    public class CreateInstallDirStep : PipelineStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, ILogger logger)
        {
            await Task.Run(() =>
            {
                args.InstallDir.CreateIfNotExists();
                args.InstallDir.GrantAccess("everyone", FileSystemRights.FullControl);
            }).ConfigureAwait(false);
        }
    }
}
