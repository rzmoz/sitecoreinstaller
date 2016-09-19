using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public interface IBuildLibraryResource
    {
        string Name { get; }
        DirPath Directory { get; }
        string FullName { get; }
        BuildLibraryType BuildLibraryType { get; }
        Path Path { get; }
    }
}
