using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Library    ;

namespace SitecoreInstaller.Infrastructure
{
    public class IoRepository : ILibraryRepository<ILibraryResource>
    {
        private readonly DirPath _root;

        public IoRepository(DirPath root)
        {
            _root = root;
        }

        public bool Delete(string name)
        {
            return _root.RawPath.ToPath(name).DeleteIfExists();
        }

        public bool Insert(string name, Stream resource, bool throwExceptionIfExists = false)
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<ILibraryResource> GetAll()
        {
            return _root.EnumeratePaths().Select(d => new IoResource(d));
        }

        public ILibraryResource Get(string name)
        {
            return new IoResource(_root.RawPath.ToPath(name));//auto resolve if dir
        }

        public bool Exists(string name)
        {
            return _root.RawPath.ToPath(name).Exists();
        }
    }
}
