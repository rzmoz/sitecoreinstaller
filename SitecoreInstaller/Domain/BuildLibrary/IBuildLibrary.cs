using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public interface IBuildLibrary
    {
        IoDir GetSitecore(string name);
        IBuildLibraryResource GetModule(string name);
        IoFile GetLicense(string name);
    }
}