using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DotNet.Basics.IO;
using Newtonsoft.Json;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Pipelines.LocalInstall;
using SitecoreInstaller.Pipelines.LocalUnInstall;

namespace SitecoreInstaller.Host.Controllers
{
    [RoutePrefix("api/local/deployments")]
    public class DeploymentsController : ApiController
    {
        private readonly InstallLocalPipeline _installLocalPipeline;
        private readonly UnInstallLocalPipeline _unInstallLocalPipeline;
        private readonly LocalDeploymentsService _localDeploymentsService;

        public DeploymentsController(InstallLocalPipeline installLocalPipeline, UnInstallLocalPipeline unInstallLocalPipeline, LocalDeploymentsService localDeploymentsService)
        {
            _installLocalPipeline = installLocalPipeline;
            _unInstallLocalPipeline = unInstallLocalPipeline;
            _localDeploymentsService = localDeploymentsService;
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage GetLocalDeployments()
        {
            var infos = _localDeploymentsService.GetDeploymentInfos();
            return Request.CreateResponse(HttpStatusCode.OK, infos);
        }

        [Route("{name}")]
        [HttpGet]
        public HttpResponseMessage GetLocalDeployment(string name)
        {
            var deploymentInfo = _localDeploymentsService.GetDeploymentInfo(name);
            if (deploymentInfo == null)
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, $"Deployment not found: {name}");
            return Request.CreateResponse(HttpStatusCode.OK, deploymentInfo);
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

                var args = new InstallLocalArgs { Info = info };
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
            var args = new UnInstallLocalArgs { Info = { Name = name } };
            await _unInstallLocalPipeline.RunAsync(args).ConfigureAwait(false);
            return Request.CreateResponse(args.WasDeleted ? HttpStatusCode.OK : HttpStatusCode.Conflict);
        }
    }
}
