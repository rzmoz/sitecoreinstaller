﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNet.Basics.IO;
using SitecoreInstaller.BuildLibrary;

namespace SitecoreInstaller.Host.Controllers
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
            return GetBuildLibraryResourcesResponse(Request, bl => bl.GetLicenses().Select(l => LicenseInfo.Load(l.Path.ToFile())));
        }

        [Route("licenses/{name}")]
        [HttpGet]
        public HttpResponseMessage GetLicense(string name)
        {
            return GetBuildLibraryResourceResponse(Request, bl => LicenseInfo.Load(bl.GetLicense(name).Path.ToFile()));
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

        private HttpResponseMessage GetBuildLibraryResourceResponse<T>(HttpRequestMessage request, Func<LocalBuildLibrary, T> getFunc)
        {
            var res = getFunc(_buildLibrary);
            if (res == null)
                return request.CreateResponse(HttpStatusCode.NoContent);
            return request.CreateResponse(HttpStatusCode.OK, res);
        }
        private HttpResponseMessage GetBuildLibraryResourcesResponse<T>(HttpRequestMessage request, Func<LocalBuildLibrary, IEnumerable<T>> getFunc)
        {
            var resources = getFunc(_buildLibrary);
            return request.CreateResponse(HttpStatusCode.OK, resources);
        }
    }
}
