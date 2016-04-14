using System.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public interface IBuildLibraryResource
    {
        string Name { get; }
        DirectoryInfo Directory { get; }
        string FullName { get; }
        BuildLibraryType BuildLibraryType { get; }
        FileSystemInfo FileSystemInfo { get; }
    }
}
