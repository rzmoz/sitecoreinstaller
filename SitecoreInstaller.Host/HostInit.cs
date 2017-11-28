using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.WebApi;
using DotNet.Basics.Collections;
using DotNet.Basics.Tasks.Pipelines;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace SitecoreInstaller.Host
{
    public class HostInit
    {
        public HostInit(Func<ILogger> initLogger)
        {
            if (initLogger == null) throw new ArgumentNullException(nameof(initLogger));
            Logger = initLogger();
            if (Logger == null)
                throw new ArgumentException("initLogger() returned null. Must return instance");
        }

        public ILogger Logger { get; }
        public IContainer Container { get; private set; }

        public void ConfigureServices(Action<ContainerBuilder> initServices)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => Logger).As<ILogger>().SingleInstance();

            initServices(containerBuilder);

            Container = containerBuilder.Build();

            Logger.LogDebug("Container registrations:");
            var registrations = new StringBuilder();
            foreach (var registration in Container.ComponentRegistry.Registrations)
                registrations.AppendLine($"{JsonConvert.SerializeObject(registration.Services.Select(s => s.Description))}");
            Logger.LogTrace(registrations.ToString());
        }

        public void UseFileServer(IAppBuilder app)
        {
            Logger.LogInformation($"Initializing File Server");

            var fileSystem = new PhysicalFileSystem("Client");
            //file server
            app.UseFileServer(new FileServerOptions
            {
                FileSystem = fileSystem,
                DefaultFilesOptions = { DefaultFileNames = { "index.html" } }
            });
            Logger.LogDebug($"File Server initialized in: {fileSystem.Root}");
        }

        public void UseWebApi(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            Logger.LogInformation("Initalizing WebApi");
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            Logger.LogTrace($"{nameof(config.IncludeErrorDetailPolicy)}: {config.IncludeErrorDetailPolicy }");
            Logger.LogTrace($"{nameof(config.DependencyResolver)}: {config.DependencyResolver.GetType().FullName}");

            // Json settings
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Include,
                TypeNameHandling = TypeNameHandling.None
            };
            config.Formatters.JsonFormatter.SerializerSettings = JsonConvert.DefaultSettings();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));

            Logger.LogDebug($"Supported Media Types:");
            config.Formatters.JsonFormatter.SupportedMediaTypes.ForEach(smt => Logger.LogTrace(smt.MediaType));

            config.EnsureInitialized();
            app.UseWebApi(config);
            Logger.LogDebug("WebApi initialized");
        }

        public void InitPipeline<T>(Pipeline<T> pipeline) where T : class, new()
        {
            /*var logger = pipeline.NLog();

            pipeline.Started += args =>
            {
                logger.Trace($"{args.Name} started..");
            };
            pipeline.Ended += args =>
            {
                var msg = $"{args.Name} ended";
                if (args.Issues.Any())
                    msg += " with issues:";

                logger.Trace(msg);
                if (args.Issues.Any())
                {
                    foreach (var issue in args.Issues)
                    {
                        logger.Error($"\r\n{issue.Message}\r\n\r\n");
                        if (issue.Exception != null)
                            logger.Debug($"{issue.Exception}\r\n\r\n");
                    }
                }
            };*/
        }
    }
}
