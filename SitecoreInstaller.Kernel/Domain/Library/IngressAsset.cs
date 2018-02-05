using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public abstract class IngressAsset : LibraryAsset
    {
        protected IngressAsset(string name, string container, PathType pathType) : base(name, container, pathType)
        {
        }

        public abstract bool Extract(DirPath containerDir);
    }
}
