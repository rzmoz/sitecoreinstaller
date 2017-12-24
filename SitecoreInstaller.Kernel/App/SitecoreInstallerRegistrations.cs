using Autofac;
using DotNet.Basics.Autofac;
using SitecoreInstaller.Domain.Library;
using SitecoreInstaller.Infrastructure.Library;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IRegistrations
    {
        public void RegisterIn(AutofacBuilder builder)
        {
            builder.RegisterType<LibraryIoRepository>().As<ILibraryRepository>().AsSelf().SingleInstance();
        }
    }
}
