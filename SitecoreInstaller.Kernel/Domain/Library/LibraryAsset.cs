using System;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public abstract class LibraryAsset
    {
        protected LibraryAsset(string name, string container, PathType pathType)
        {
            PathType = pathType;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public string Name { get; }
        public string Container { get; }
        public PathType PathType { get; }

        public override string ToString()
        {
            return $"{Container}\\{Name}";
        }
    }
}
