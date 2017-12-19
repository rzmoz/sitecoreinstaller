using Autofac;
using DotNet.Basics.Extensions.Autofac;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IAutofacRegistrations
    {
        public void RegisterIn(ContainerBuilder builder)
        {
            builder.RegisterType<SitecoreInstallerRepository>().AsSelf().As<IInitializable>();
        }
    }
}
