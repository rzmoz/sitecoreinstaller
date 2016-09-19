using DotNet.Basics.Ioc;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Runtime.Install;
using SitecoreInstaller.RuntimeServices;

namespace SitecoreInstaller.Runtime
{
    public class SiRegistrations : ISimpleRegistrations
    {
        public void RegisterIn(SimpleContainer container)
        {
            container.Register<IBuildLibrary, IOBuildLibrary>();
            container.Register<RuntimeServicesProvider>();
            container.Register<Pipeline<InstallArgs>>();
        }
    }
}
