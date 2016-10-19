using System.Net;
using System.Net.Http;
using System.Web.Http;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.RestHost.Controllers
{
    [RoutePrefix("api/iis")]
    public class IisManagementController : ApiController
    {
        private IisManagementService _iisManagementService;

        public IisManagementController(IisManagementService iisManagementService)
        {
            _iisManagementService = iisManagementService;
        }

        [Route("{name}")]
        [HttpPut]
        public HttpResponseMessage CreateApplication(string name)
        {
            _iisManagementService.CreateApplication(new IisApplicationSettings(name));
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }
    }
}
