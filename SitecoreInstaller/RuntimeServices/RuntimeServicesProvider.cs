using System.Threading.Tasks;
using DotNet.Basics.IO;

namespace SitecoreInstaller.RuntimeServices
{
    public class RuntimeServicesProvider
    {
        public async Task InstallRuntimeServicesAsync(DirPath websiteRoot)
        {
            var targetDir = websiteRoot.ToDir("temp", "sitecoreinstaller");
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
