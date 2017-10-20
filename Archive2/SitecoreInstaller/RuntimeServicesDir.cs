using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class RuntimeServicesDir : DirPath
    {
        public RuntimeServicesDir(DirPath fullPath) : base(fullPath.FullName)
        { }

        public FilePath AdminLogin => this.ToFile("AdminLogin.aspx");
        public FilePath DeserializeItems => this.ToFile("DeserializeItems.aspx");
        public FilePath InstallPackageService => this.ToFile("InstallPackageService.aspx");
        public FilePath InstallPackageStatusService => this.ToFile("InstallPackageStatusService.aspx");
        public FilePath PostInstallService => this.ToFile("PostInstallService.aspx");
        public FilePath PublishSite => this.ToFile("PublishSite.aspx");
    }
}
