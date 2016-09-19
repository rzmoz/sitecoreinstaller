using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.Domain.RuntimeServices;

namespace SitecoreInstaller.App.Install
{
    public class CopyRuntimeServicesStep : PipelineStep<InstallArgs>
    {
        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            var targetDir = args.WebsiteRoot.ToDir("temp", "sitecoreinstaller");
            targetDir.CreateIfNotExists();

            await Task.WhenAll(
                            Task.Run(() => { RuntimeServiceResources.AdminLogin.WriteAllText(targetDir, RuntimeServiceNames.AdminLogin); }),
                            Task.Run(() => { RuntimeServiceResources.DeserializeItems.WriteAllText(targetDir, RuntimeServiceNames.DeserializeItems); }),
                            Task.Run(() => { RuntimeServiceResources.InstallPackageService.WriteAllText(targetDir, RuntimeServiceNames.InstallPackageService); }),
                            Task.Run(() => { RuntimeServiceResources.InstallPackageStatusService.WriteAllText(targetDir, RuntimeServiceNames.InstallPackageStatusService); }),
                            Task.Run(() => { RuntimeServiceResources.PostInstallService.WriteAllText(targetDir, RuntimeServiceNames.PostInstallService); }),
                            Task.Run(() => { RuntimeServiceResources.PublishSiteService.WriteAllText(targetDir, RuntimeServiceNames.PublishSiteService); })
                            ).ConfigureAwait(false);
        }
    }
}
