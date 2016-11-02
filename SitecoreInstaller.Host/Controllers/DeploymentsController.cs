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
                var info = JsonConvert.DeserializeObject<DeploymentInfo>(argsJson);

                if (string.IsNullOrWhiteSpace(info.Name) ||
                    string.IsNullOrWhiteSpace(info.Sitecore) ||
                    string.IsNullOrWhiteSpace(info.License))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, info);

                var args = new LocalInstallArgs { Info = info };
                await _installLocalPipeline.RunAsync(args).ConfigureAwait(false);

                return Request.CreateResponse(HttpStatusCode.Accepted, args);
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
            var args = new UnInstallArgs { Info = { Name = name } };
            await _unInstallLocalPipeline.RunAsync(args).ConfigureAwait(false);
            return Request.CreateResponse(args.WasDeleted ? HttpStatusCode.OK : HttpStatusCode.Conflict);
        }
    }
}
