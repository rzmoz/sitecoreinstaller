using CSharp.Basics.IO;

namespace SitecoreInstaller.Kernel.Domain
{
    public interface IBuildLibrary
    {
        IoDir GetSitecore(string name);
        IoDir GetModule(string name);
        IoFile GetLicense(string name);
    }
}