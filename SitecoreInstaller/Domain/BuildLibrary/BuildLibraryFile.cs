using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryFile : IBuildLibraryResource
    {
        public IoDir Dir { get; }
        public IoFile File { get; }
    }
}
