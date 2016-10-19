using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SitecoreInstaller.Projects;

namespace SitecoreInstaller.RestHost.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> NewSitecoreDeployment()
        {
            var settingsJson = await Request.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var settings = JsonConvert.DeserializeObject<ProjectSettings>(settingsJson);
                return Request.CreateResponse(HttpStatusCode.Accepted, settings);
            }
            catch (JsonReaderException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
