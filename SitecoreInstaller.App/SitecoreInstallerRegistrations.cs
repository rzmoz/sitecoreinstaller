using Autofac;
using DotNet.Basics.Autofac;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Resources;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IAutofacRegistrations
    {
        public void RegisterIn(AutofacBuilder builder)
        {
            builder.RegisterType<SitecoreInstallerConfig>().AsSelf();
            builder.RegisterType<SitecoreInstallerRepository>().AsSelf().As<IInitializable>();
        }
    }
}
