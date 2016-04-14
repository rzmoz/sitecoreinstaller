using System.Collections.Generic;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public interface IBuildLibrary
    {
        IBuildLibraryResource Get(string name, BuildLibraryType buildLibraryType);
        IEnumerable<IBuildLibraryResource> Get(string[] names, BuildLibraryType buildLibraryType);
        IEnumerable<IBuildLibraryResource> GetSitecores(params string[] names);
        IEnumerable<IBuildLibraryResource> GetLicenses(params string[] names);
        IEnumerable<IBuildLibraryResource> GetModules(params string[] names);
    }
}
