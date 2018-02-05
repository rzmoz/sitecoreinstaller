using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public class Sitecore8Egress : EgressAsset
    {
        public Sitecore8Egress(string name) : base(name, ContainerNames.Sitecores, PathType.Dir)
        {
        }
    }
}
