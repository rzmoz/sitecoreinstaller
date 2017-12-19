using System.Collections.Generic;
using System.IO;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using SitecoreInstaller.Domain.Library;

namespace SitecoreInstaller.Infrastructure.Library
{
    public abstract class IoRepository<T> : ILibraryRepository
    {
        public bool Insert(IIngressAsset ingress, bool throwExceptionIfExists = false)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IEgressAsset> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEgressAsset Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(IEgressAsset asset)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(IEgressAsset asset)
        {
            throw new System.NotImplementedException();
        }
    }
}
