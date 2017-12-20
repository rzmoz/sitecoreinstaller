using Autofac;
using DotNet.Basics.Extensions.Autofac;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Library;
using SitecoreInstaller.Infrastructure.Library;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IAutofacRegistrations
    {
        public void RegisterIn(ContainerBuilder builder)
        {
            builder.RegisterType<LibraryIoRepository>().SingleInstance().AsSelf().As<ILibraryRepository>().As<IInitializable>();
        }
    }
}
