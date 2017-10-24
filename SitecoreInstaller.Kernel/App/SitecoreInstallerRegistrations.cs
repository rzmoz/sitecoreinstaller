using Autofac;
using DotNet.Basics.Extensions.Autofac;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.InstallerLib;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IAutofacRegistrations
    {
        public void RegisterIn(ContainerBuilder builder)
        {
            builder.RegisterType<InstallerLibConfig>().SingleInstance().AsSelf();
            builder.RegisterType<SitecoreInstallerRepository>().AsSelf().As<IInitializable>();
        }
    }
}
