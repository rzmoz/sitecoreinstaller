using System.Collections.Generic;

namespace SitecoreInstaller.BuildLibrary
{
    public interface IBuildLibrary
    {
        IBuildLibraryResource Get(string name, BuildLibraryType buildLibraryType);
        IBuildLibraryResource GetSitecore(string name);
        IBuildLibraryResource GetLicense(string name);
        IBuildLibraryResource GetModule(string name);

        IEnumerable<IBuildLibraryResource> Get(string[] names, BuildLibraryType buildLibraryType);
        IEnumerable<IBuildLibraryResource> GetSitecores(params string[] names);
        IEnumerable<IBuildLibraryResource> GetLicenses(params string[] names);
        IEnumerable<IBuildLibraryResource> GetModules(params string[] names);
    }
}
