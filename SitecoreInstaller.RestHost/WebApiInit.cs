using System.Web.Http;
using Autofac.Integration.WebApi;
using NLog;
using Owin;
using SitecoreInstaller.Runtime;

namespace SitecoreInstaller.RestHost
{
    public class WebApiInit
    {
        public void Configuration(IAppBuilder appBuilder, RuntimeConfigurator runtime, ILogger logger)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            logger.Trace("Initalizing WebApi...");

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(runtime.Container);
            appBuilder.UseWebApi(config);

            logger.Debug($"{nameof(config.IncludeErrorDetailPolicy)}: {config.IncludeErrorDetailPolicy }");
            logger.Debug($"{nameof(config.DependencyResolver)}: {config.DependencyResolver.GetType().FullName}");

            config.EnsureInitialized();

            logger.Trace("WebApi initialized");
        }
    }
}
