using System.Net;
using System.Net.Http;
using System.Web.Http;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.RestHost.Controllers
{
    [RoutePrefix("api/iis")]
    public class IisManagementController : ApiController
    {
        private readonly IisManagementService _iisManagementService;

        public IisManagementController(IisManagementService iisManagementService)
        {
            _iisManagementService = iisManagementService;
        }

        [Route("{name}")]
        [HttpDelete]
        public HttpResponseMessage DeleteApplication(string name)
        {
            _iisManagementService.DeleteApplication(name);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
