using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SitecoreInstaller.Host.ClientControllers
{
    public class ClientController : ApiController
    {
        private readonly SiPageRenderer _pageRenderer;

        public ClientController(SiPageRenderer pageRenderer)
        {
            _pageRenderer = pageRenderer;
        }

        [HttpGet]
        [Route]
        public HttpResponseMessage Index()
        {
            return new HttpResponseMessage
            {
                Headers = { Location = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/index") },
                StatusCode = HttpStatusCode.MovedPermanently
            };
        }

        [HttpGet]
        [Route("{name}")]
        public HttpResponseMessage Pages(string name)
        {
            var statusCode = HttpStatusCode.OK;
            string html;
            try
            {
                html = _pageRenderer.Render(name);
            }
            catch (FileNotFoundException)
            {
                html = _pageRenderer.RenderNotFound();
                statusCode = HttpStatusCode.NotFound;
            }
            return new HttpResponseMessage
            {
                Content = new StringContent(html)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("text/html") }
                },
                StatusCode = statusCode
            };
        }
    }
}
