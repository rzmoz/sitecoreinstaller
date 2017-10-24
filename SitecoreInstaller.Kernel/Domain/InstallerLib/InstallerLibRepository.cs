using System.Collections.Generic;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.InstallerLib
{
    public class InstallerLibRepository<T> : DirPath
    {
        public InstallerLibRepository(string path, params string[] segments) : base(path, segments)
        {
        }
        
        public string Name { get; }

        public IEnumerable<T> GetAll()
        {
            return EnumeratePaths();
        }

        
    }
}
