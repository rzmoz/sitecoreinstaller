using Autofac;
using DotNet.Basics.Ioc;
using SitecoreInstaller.PreflightChecks;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Runtime
{
    public class SitecoreInstallerRegistrations : IIocRegistrations
    {
        public void RegisterIn(ContainerBuilder builder)
        {
            //web server registrations
            builder.RegisterType<HostFile>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<IisManagementService>().As<IPreflightCheck>().AsSelf().SingleInstance();
        }
    }
}
