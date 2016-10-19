using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.RestHost.Controllers
{
    [RoutePrefix("api/sites")]
    public class SitesController : ApiController
    {
        private readonly WebsiteService _websiteService;

        public SitesController(WebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> NewSitecoreDeployment()
        {
            var settingsJson = await Request.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var settings = JsonConvert.DeserializeObject<ProjectSettings>(settingsJson);
                _websiteService.InitProjectDir(settings.Name);
                return Request.CreateResponse(HttpStatusCode.Accepted, settings);
            }
            catch (JsonReaderException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{name}")]
        [HttpDelete]
        public HttpResponseMessage DeleteSitecoreDeployment(string name)
        {
            var success = _websiteService.DeleteProjectDir(name);
            return Request.CreateResponse(success ? HttpStatusCode.OK : HttpStatusCode.Conflict);
        }
    }
}
