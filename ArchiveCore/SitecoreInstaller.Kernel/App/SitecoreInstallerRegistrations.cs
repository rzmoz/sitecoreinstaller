using Autofac;
using DotNet.Basics.Extensions.Autofac;
using SitecoreInstaller.Domain.Library;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Infrastructure.Library;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IAutofacRegistrations
    {
        public void RegisterIn(ContainerBuilder builder)
        {
            builder.RegisterType<LibraryConfig>().SingleInstance().AsSelf();
            builder.RegisterType<SitecoreInstallerRepository>().AsSelf().As<IInitializable>();
        }
    }
}
