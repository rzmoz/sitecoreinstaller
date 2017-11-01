using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain
{
    public interface IResource
    {
        string Name { get; }
        PathInfo Path { get; }
    }
}
