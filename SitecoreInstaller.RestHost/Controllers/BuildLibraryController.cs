using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SitecoreInstaller.BuildLibrary;

namespace SitecoreInstaller.RestHost.Controllers
{
    [RoutePrefix("api/buildlibrary")]
    public class BuildLibraryController : ApiController
    {
        private readonly LocalBuildLibrary _buildLibrary;

        public BuildLibraryController(LocalBuildLibrary buildLibrary)
        {
            _buildLibrary = buildLibrary;
        }

        [Route("sitecores")]
        [HttpGet]
        public HttpResponseMessage GetSitecores()
        {
            return GetBuildLibraryResourcesResponse(Request, bl => bl.GetSitecores());
        }

        [Route("sitecores/{name}")]
        [HttpGet]
        public HttpResponseMessage GetSitecore(string name)
        {
            return GetBuildLibraryResourceResponse(Request, bl => bl.GetSitecore(name));
        }

        [Route("licenses")]
        [HttpGet]
        public HttpResponseMessage GetLicenses()
        {
            return GetBuildLibraryResourcesResponse(Request, bl => bl.GetLicenses());
        }

        [Route("licenses/{name}")]
        [HttpGet]
        public HttpResponseMessage GetLicense(string name)
        {
            return GetBuildLibraryResourceResponse(Request, bl => bl.GetLicense(name));
        }

        [Route("modules/{name}")]
        [HttpGet]
        public HttpResponseMessage GetModule(string name)
        {
            return GetBuildLibraryResourceResponse(Request, bl => bl.GetModule(name));
        }

        [Route("modules")]
        [HttpGet]
        public HttpResponseMessage GetModules()
        {
            return GetBuildLibraryResourcesResponse(Request, bl => bl.GetModules());
        }

        private HttpResponseMessage GetBuildLibraryResourceResponse(HttpRequestMessage request, Func<LocalBuildLibrary, BuildLibraryResource> getFunc)
        {
            var res = getFunc(_buildLibrary);
            if (res == null)
                return request.CreateResponse(HttpStatusCode.NoContent);
            return request.CreateResponse(HttpStatusCode.OK, res);
        }
        private HttpResponseMessage GetBuildLibraryResourcesResponse(HttpRequestMessage request, Func<LocalBuildLibrary, IEnumerable<BuildLibraryResource>> getFunc)
        {
            var resources = getFunc(_buildLibrary);
            return request.CreateResponse(HttpStatusCode.OK, resources.Select(res => res.Path.Name));
        }
    }
}
