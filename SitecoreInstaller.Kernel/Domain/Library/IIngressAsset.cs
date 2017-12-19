using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public interface IIngressAsset : ILibraryAsset
    {
        PathInfo Source { get; }
        PathType SourceType { get; }
    }
}
