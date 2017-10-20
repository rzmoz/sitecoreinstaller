using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using DotNet.Basics.Autofac;
using DotNet.Basics.NLog;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Targets;
using NLog;
using Owin;
using SitecoreInstaller.Kernel.Cli;

namespace SitecoreInstaller.Host
{
    public class HostInit
    {
        public HostInit()
        {
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            HostName = method.DeclaringType?.Namespace ?? "Host";
        }

        public string HostName { get; }
        public IContainer Container { get; private set; }

        public bool LogAppInitializing()
        {
            this.NLog().Trace(AsciiArts.Logo);
            this.NLog().Debug($"Runtime initializing...");
            this.NLog().Trace($"UTC Time: {DateTime.UtcNow}");
            this.NLog().Trace($"Host Version: {FileVersionInfo.GetVersionInfo(typeof(HostInit).Assembly.Location).FileVersion}");
            this.NLog().Trace($"Running as: {System.Security.Principal.WindowsIdentity.GetCurrent().Name}");

            return true;
        }

        public void InitRegistrations(Action<AutofacBuilder> iocRegistrations = null)
        {
            InitArea("IocContainer", errorMsgs =>
            {
                try
                {
                    var builder = new AutofacBuilder(false);
                    iocRegistrations?.Invoke(builder);
                    Container = builder.Container;
                    foreach (var registration in Container.ComponentRegistry.Registrations)
                        this.NLog().Debug($"{JsonConvert.SerializeObject(registration.Services.Select(s => s.Description)) }");
                }
                catch (Exception e)
                {
                    errorMsgs.Add(e.ToString());
                }
            });
        }

        private void InitArea(string areaName, Action<IList<string>> initFunc, string startingVerb = "initializing", string endedVerb = "Initialized")
        {
            this.NLog().Debug($"{areaName} {startingVerb}...");
            var errorMessages = new List<string>();
            initFunc(errorMessages);
            var success = errorMessages.Count == 0;
            if (success)
                this.NLog().Debug($"{areaName} {endedVerb}");
            else
            {
                foreach (var errorMessage in errorMessages)
                    this.NLog().Error(errorMessage);

                this.NLog().Fatal($"{startingVerb} of {areaName} failed. Application will not run properly. Aborting...");
            }
        }

        public bool InitLogging()
        {
            using (var logConfigurator = new NLogConfigurator())
            {
                logConfigurator.AddTarget(new ColoredConsoleTarget
                {
                    Layout = "${message}"
                }.WithOutputColors());

                logConfigurator.AddTarget(new MethodCallTarget
                {
                    MethodName = $"{typeof(Program).FullName}, {typeof(Program).Assembly.FullName}"
                }, "*", LogLevel.Fatal);
                logConfigurator.Build();
                return true;
            }
        }

        public void InitWebApi(IAppBuilder app, IContainer container)
        {
            app.NLog().Debug("Initalizing WebApi...");
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            app.NLog().Trace($"{nameof(config.IncludeErrorDetailPolicy)}: {config.IncludeErrorDetailPolicy }");
            app.NLog().Trace($"{nameof(config.DependencyResolver)}: {config.DependencyResolver.GetType().FullName}");

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

            config.EnsureInitialized();
            app.UseWebApi(config);
            app.NLog().Debug("WebApi initialized");
        }
        public void InitFileServer(IAppBuilder app)
        {
            app.NLog().Debug("Initializing File Server...");

            //file server
            app.UseFileServer(new FileServerOptions
            {
                FileSystem = new PhysicalFileSystem("wwwroot"),
                DefaultFilesOptions = { DefaultFileNames = { "index.html" } }
            });
            app.NLog().Debug("File Server initialized");
        }
    }
}
