using System;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
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
        [HttpPut]
        public HttpResponseMessage CreateApplication(string name)
        {
            try
            {
                _iisManagementService.CreateApplication(name);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (COMException e)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Application already exists: {name}");
            }
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
