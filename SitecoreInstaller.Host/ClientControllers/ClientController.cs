using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Host.ClientControllers
{
    public class ClientController : ApiController
    {
        private readonly PageFactory _pageFactory;

        public ClientController()
        {
            _pageFactory = new PageFactory(@".\client".ToDir("pages"));
        }

        [HttpGet]
        [Route]
        public HttpResponseMessage Index()
        {
            return new HttpResponseMessage
            {
                Headers = { Location = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/Dashboard") },
                StatusCode = HttpStatusCode.MovedPermanently
            };
        }

        [HttpGet]
        [Route("{name}")]
        public HttpResponseMessage Pages(string name)
        {
            var page = _pageFactory.Get(name);

            return new HttpResponseMessage
            {
                Content = new StringContent(page.Html)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("text/html") }
                },
                StatusCode = page.Is404 ? HttpStatusCode.NotFound : HttpStatusCode.OK
            };
        }
    }
}
