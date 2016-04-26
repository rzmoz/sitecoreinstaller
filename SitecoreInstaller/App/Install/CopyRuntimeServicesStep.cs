using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using Microsoft.Extensions.Logging;
using SitecoreInstaller.Domain.RuntimeServices;

namespace SitecoreInstaller.App.Install
{
    public class CopyRuntimeServicesStep : PipelineStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, ILogger logger)
        {
            var targetDir = args.WebsiteRoot.ToDir("temp", "sitecoreinstaller");
            await Task.WhenAll(
                            Task.Run(() => { RuntimeServiceResources.AdminLogin.WriteToDisk(targetDir, RuntimeServiceNames.AdminLogin); }),
                            Task.Run(() => { RuntimeServiceResources.DeserializeItems.WriteToDisk(targetDir, RuntimeServiceNames.DeserializeItems); }),
                            Task.Run(() => { RuntimeServiceResources.InstallPackageService.WriteToDisk(targetDir, RuntimeServiceNames.InstallPackageService); }),
                            Task.Run(() => { RuntimeServiceResources.InstallPackageStatusService.WriteToDisk(targetDir, RuntimeServiceNames.InstallPackageStatusService); }),
                            Task.Run(() => { RuntimeServiceResources.PostInstallService.WriteToDisk(targetDir, RuntimeServiceNames.PostInstallService); }),
                            Task.Run(() => { RuntimeServiceResources.PublishSiteService.WriteToDisk(targetDir, RuntimeServiceNames.PublishSiteService); })
                            ).ConfigureAwait(false);
        }
    }
}
