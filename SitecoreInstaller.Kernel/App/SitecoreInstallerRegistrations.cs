using DotNet.Basics.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SitecoreInstaller.Infrastructure.Library;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRegistrations : IRegistrations
    {
        public void RegisterIn(IServiceCollection services)
        {
            services.AddSingleton<LibraryIoRepository>();
        }
    }
}
