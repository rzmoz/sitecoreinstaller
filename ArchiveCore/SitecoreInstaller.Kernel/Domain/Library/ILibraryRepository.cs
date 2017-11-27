using System.Collections.Generic;

namespace SitecoreInstaller.Domain.Library
{
    public interface ILibraryRepository
    {
        bool Insert(IIngressAsset ingress, bool throwExceptionIfExists = false);

        IEnumerable<IEgressAsset> GetAll();
        IEgressAsset Get(string name);

        bool Exists(IEgressAsset asset);
        bool Delete(IEgressAsset asset);
    }
}
