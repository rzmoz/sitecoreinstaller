using Autofac;
using DotNet.Basics.Ioc;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.PreflightChecks;
using SitecoreInstaller.Website;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Runtime
{
    public class SitecoreInstallerRegistrations : IIocRegistrations
    {
        public void RegisterIn(ContainerBuilder builder)
        {
            //environment registrations
            builder.RegisterType<EnvironmentSettings>().AsSelf().SingleInstance();

            //web server registrations
            builder.RegisterType<HostFile>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<IisManagementService>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<IisApplicationSettingsFactory>().AsSelf().SingleInstance();

            //build lib
            builder.RegisterType<LocalBuildLibrary>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //web site registrations
            builder.RegisterType<WebsiteService>().As<IPreflightCheck>().AsSelf().SingleInstance();
        }
    }
}
