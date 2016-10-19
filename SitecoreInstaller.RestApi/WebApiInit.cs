using System.Web.Http;
using Owin;

namespace SitecoreInstaller.RestApi
{
    public class WebApiInit
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();


            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            appBuilder.UseWebApi(config);
            config.EnsureInitialized();
        }
    }
}
