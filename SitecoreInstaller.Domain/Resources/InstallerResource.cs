using System;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.Resources
{
    public abstract class InstallerResource<T> where T : PathInfo
    {
        protected InstallerResource(T path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Name = path.Name;
        }

        public string Name { get; }
        public T Path { get; }
    }
}
