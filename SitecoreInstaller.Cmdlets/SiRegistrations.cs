using DotNet.Basics.Ioc;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Cmdlets
{
    public class SiRegistrations : IDotNetRegistrations
    {
        public void RegisterIn(IDotNetContainer container)
        {
            container.BindType<IBuildLibrary, IOBuildLibrary>();
        }
    }
}
