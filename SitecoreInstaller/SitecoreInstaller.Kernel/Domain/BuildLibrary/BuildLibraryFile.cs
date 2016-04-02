using DotNet.Basics.IO;

namespace SitecoreInstaller.Kernel.Domain.BuildLibrary
{
    public class BuildLibraryFile : IBuildLibraryResource
    {
        public IoDir Dir { get; }
        public IoFile File { get; }
    }
}
