namespace SitecoreInstaller.Kernel.Domain
{
    public interface IBuildLibrary
    {
        IBuildLibraryResource GetSitecore(string name);
        IBuildLibraryResource GetModule(string name);
        IBuildLibraryResource GetLicense(string name);
    }
}
