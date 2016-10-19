using Autofac;
using DotNet.Basics.Ioc;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Pipelines.Install;
using SitecoreInstaller.Pipelines.UnInstall;
using SitecoreInstaller.PreflightChecks;
using SitecoreInstaller.Website;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Runtime
{
    public class SitecoreInstallerRegistrations : IIocRegistrations
    {
        public void RegisterIn(IocBuilder builder)
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

            //pipelines
            builder.Register(c => new InstallPipeline(builder.Container)).AsSelf().SingleInstance();
            builder.Register(c => new UnInstallPipeline(builder.Container)).AsSelf().SingleInstance();
        }
    }
}
