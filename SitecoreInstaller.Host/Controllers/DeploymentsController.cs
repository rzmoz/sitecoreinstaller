using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SitecoreInstaller.Pipelines.Install;
using SitecoreInstaller.Pipelines.UnInstall;

namespace SitecoreInstaller.Host.Controllers
{
    [RoutePrefix("api/local/deployments")]
    public class DeploymentsController : ApiController
    {
        private readonly InstallLocalPipeline _installLocalPipeline;
        private readonly UnInstallLocalPipeline _unInstallLocalPipeline;

        public DeploymentsController(InstallLocalPipeline installLocalPipeline, UnInstallLocalPipeline unInstallLocalPipeline)
        {
            _installLocalPipeline = installLocalPipeline;
            _unInstallLocalPipeline = unInstallLocalPipeline;
        }

        [Route]
        [HttpGet]
        public async Task<HttpResponseMessage> GetLocalDeployment()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, "");
        }

        [Route]
        [HttpPut]
        public async Task<HttpResponseMessage> NewLocalDeployment()
        {
            var argsJson = await Request.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var installArgs = JsonConvert.DeserializeObject<LocalInstallArgs>(argsJson);

                if (string.IsNullOrWhiteSpace(installArgs.Name) ||
                    string.IsNullOrWhiteSpace(installArgs.Sitecore) ||
                    string.IsNullOrWhiteSpace(installArgs.License))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, installArgs);


                await _installLocalPipeline.RunAsync(installArgs).ConfigureAwait(false);
                return Request.CreateResponse(HttpStatusCode.Accepted, installArgs);
            }
            catch (JsonReaderException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{name}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteLocalDeployment(string name)
        {
            var args = await _unInstallLocalPipeline.RunAsync(new UnInstallArgs { Name = name }).ConfigureAwait(false);
            return Request.CreateResponse(args.WasDeleted ? HttpStatusCode.OK : HttpStatusCode.Conflict);
        }
    }
}
