using Autofac;
using DotNet.Basics.Autofac;
using SitecoreInstaller.Domain.Library;
using SitecoreInstaller.Infrastructure.Library;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IRegistrations
    {
        private readonly ApplicationSettings _applicationSettings;

        public SitecoreInstallerRegistrations(ApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public void RegisterIn(AutofacBuilder builder)
        {
            builder.RegisterType<LibraryIoRepository>()
                    .As<ILibraryRepository>()
                    .AsSelf()
                    .SingleInstance()
                    .WithParameter(new TypedParameter(typeof(string), _applicationSettings.LibraryRootDir));
        }
    }
}
