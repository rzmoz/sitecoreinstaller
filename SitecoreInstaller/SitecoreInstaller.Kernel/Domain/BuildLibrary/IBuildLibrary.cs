using CSharp.Basics.IO;

namespace SitecoreInstaller.Kernel.Domain.BuildLibrary
{
    public interface IBuildLibrary
    {
        IoDir GetSitecore(string name);
        IBuildLibraryResource GetModule(string name);
        IoFile GetLicense(string name);
    }
}