using DotNet.Basics.Ioc;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Cmdlets
{
    public class SiRegistrations : ISimpleRegistrations
    {
        public void RegisterIn(SimpleContainer container)
        {
            container.Register<IBuildLibrary, IOBuildLibrary>();
        }
    }
}
