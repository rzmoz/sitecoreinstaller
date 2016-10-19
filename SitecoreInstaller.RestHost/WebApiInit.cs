using System.Web.Http;
using System.Web.Http.ExceptionHandling;
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
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            appBuilder.UseWebApi(config);

            logger.Debug($"{nameof(config.IncludeErrorDetailPolicy)}: {config.IncludeErrorDetailPolicy }");
            logger.Debug($"{nameof(config.DependencyResolver)}: {config.DependencyResolver.GetType().FullName}");

            config.EnsureInitialized();

            logger.Trace("WebApi initialized");
        }
    }
}
