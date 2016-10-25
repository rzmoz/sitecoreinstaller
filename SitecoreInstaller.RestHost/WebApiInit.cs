using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using Owin;

namespace SitecoreInstaller.RestHost
{
    public class WebApiInit
    {
        public void Init(IAppBuilder appBuilder, IContainer container, ILogger logger)
        {
            logger.Debug("Initalizing WebApi...");

            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

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
            appBuilder.UseWebApi(config);
            appBuilder.UseFileServer(new FileServerOptions
            {
                FileSystem = new PhysicalFileSystem("Client"),
                DefaultFilesOptions = { DefaultFileNames = { "index.html" } }
            });
            logger.Debug("WebApi initialized");
        }
    }
}
