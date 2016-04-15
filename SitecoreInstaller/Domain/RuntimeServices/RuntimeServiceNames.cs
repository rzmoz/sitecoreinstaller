namespace SitecoreInstaller.Domain.RuntimeServices
{
    public static class RuntimeServiceNames
    {
        public static readonly string AdminLogin = $"{nameof(RuntimeServiceResources.AdminLogin)}.aspx";
        public static readonly string DeserializeItems = $"{nameof(RuntimeServiceResources.DeserializeItems)}.aspx";
        public static readonly string InstallPackageService = $"{nameof(RuntimeServiceResources.InstallPackageService)}.aspx";
        public static readonly string InstallPackageStatusService = $"{nameof(RuntimeServiceResources.InstallPackageStatusService)}.aspx";
        public static readonly string PostInstallService = $"{nameof(RuntimeServiceResources.PostInstallService)}.aspx";
        public static readonly string PublishSiteService = $"{nameof(RuntimeServiceResources.PublishSiteService)}.aspx";
    }
}
