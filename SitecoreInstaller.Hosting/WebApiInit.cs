using System.Web.Http;
using DotNet.Basics.NLog;
using NLog.Targets;
using Owin;

namespace SitecoreInstaller.Hosting
{
    public class WebApiInit
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            appBuilder.UseWebApi(config);
            config.EnsureInitialized();
            ConfigureLog();
        }

        private void ConfigureLog()
        {
            using (var nlogConf = new NLogConfigurator())
            {
                var consoleTarget = new ColoredConsoleTarget()
                {
                    Layout = "${message}"
                };

                consoleTarget.AddDefaultLogColors();

                nlogConf.AddTarget(consoleTarget.AsBuffered(flushTimeout: 250));
            }
        }
    }
}

