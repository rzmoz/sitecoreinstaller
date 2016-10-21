using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            logger.Debug("Initalizing WebApi...");

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(runtime.Container);
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            appBuilder.UseWebApi(config);

            logger.Trace($"{nameof(config.IncludeErrorDetailPolicy)}: {config.IncludeErrorDetailPolicy }");
            logger.Trace($"{nameof(config.DependencyResolver)}: {config.DependencyResolver.GetType().FullName}");

            // Json settings
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Include,
                TypeNameHandling = TypeNameHandling.None
            };

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));

            config.EnsureInitialized();

            logger.Debug("WebApi initialized");
        }
    }
}
