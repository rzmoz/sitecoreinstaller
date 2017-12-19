using System.Collections.Generic;

namespace SitecoreInstaller.Domain.Library
{
    public interface ILibraryRepository
    {
        bool Insert(IIngressAsset ingress, bool overwriteIfExists = false);

        IEnumerable<IEgressAsset> GetAll();
        IEgressAsset Get(string name);

        bool Exists(string name);
        bool Delete(string name);
    }
}
