using System.Collections.Generic;

namespace SitecoreInstaller.Domain.Library
{
    public interface ILibraryRepository
    {
        bool Insert(IngressAsset ingress, bool overwriteIfExists = false);

        IEnumerable<EgressAsset> GetAll<T>() where T : EgressAsset;
        EgressAsset Get(EgressAsset asset);

        bool Exists(EgressAsset asset);
        bool Delete(EgressAsset asset);
    }
}
