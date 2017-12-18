using System.Collections.Generic;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public interface IAssetRepository
    {
        bool Insert(IIngressAsset ingress, bool overwriteIfExists = false);

        IEnumerable<IEgressAsset> GetAll();
        IEgressAsset Get(string name);

        bool Exists(IEgressAsset asset);
        bool Delete(IEgressAsset asset);
    }
}
