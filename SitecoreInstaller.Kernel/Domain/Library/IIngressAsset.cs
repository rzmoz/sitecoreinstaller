using DotNet.Basics.Sys;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public interface IIngressAsset : ILibraryAsset
    {
        PathInfo Source { get; }
        PathType PathType { get; }
        void Extract(DirPath targetDir);
    }
}
