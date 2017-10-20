using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Host.ApiControllers
{
    [RoutePrefix("api/local/deployments")]
    public class LocalDeploymentsController : ApiController
    {
        private readonly LocalDeploymentsService _localDeploymentsService;

        public LocalDeploymentsController(LocalDeploymentsService localDeploymentsService)
        {
            _localDeploymentsService = localDeploymentsService;
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage GetLocalDeployments()
        {
            var infos = _localDeploymentsService.LoadDeploymentInfos();
            return Request.CreateResponse(HttpStatusCode.OK, infos);
        }

        [Route("{name}/status")]
        [HttpGet]
        public HttpResponseMessage GetLocalDeploymentStatus(string name)
        {
            var info = _localDeploymentsService.LoadDeploymentInfo(name);
            return Request.CreateResponse(HttpStatusCode.OK, info);
        }

        [Route("{name}")]
        [HttpGet]
        public HttpResponseMessage GetLocalDeployment(string name)
        {
            var deploymentInfo = _localDeploymentsService.LoadDeploymentInfo(name);
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

                return _localDeploymentsService.TryStartNewDeployment(info)
                    ? Request.CreateResponse(HttpStatusCode.Accepted)
                    : Request.CreateResponse(HttpStatusCode.Conflict, DeploymentStatus.InProgress);
            }
            catch (ArgumentException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (JsonReaderException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{name}")]
        [HttpDelete]
        public HttpResponseMessage DeleteLocalDeployment(string name)
        {
            return _localDeploymentsService.TryDeleteDeployment(name) ?
                Request.CreateResponse(HttpStatusCode.Accepted) :
                Request.CreateResponse(HttpStatusCode.Conflict, DeploymentStatus.InProgress);
        }
    }
}
