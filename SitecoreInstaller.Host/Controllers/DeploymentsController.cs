using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SitecoreInstaller.Pipelines.Install;
using SitecoreInstaller.Pipelines.UnInstall;

namespace SitecoreInstaller.Host.Controllers
{
    [RoutePrefix("api/deployments")]
    public class DeploymentsController : ApiController
    {
        private readonly InstallPipeline _installPipeline;
        private readonly UnInstallPipeline _unInstallPipeline;

        public DeploymentsController(InstallPipeline installPipeline, UnInstallPipeline unInstallPipeline)
        {
            _installPipeline = installPipeline;
            _unInstallPipeline = unInstallPipeline;
        }

        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> NewSitecoreDeployment()
        {
            var argsJson = await Request.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var installArgs = JsonConvert.DeserializeObject<InstallArgs>(argsJson);

                if (string.IsNullOrWhiteSpace(installArgs.Name) ||
                    string.IsNullOrWhiteSpace(installArgs.Sitecore) ||
                    string.IsNullOrWhiteSpace(installArgs.License))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, installArgs);


                await _installPipeline.RunAsync(installArgs).ConfigureAwait(false);
                return Request.CreateResponse(HttpStatusCode.Accepted, installArgs);
            }
            catch (JsonReaderException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("{name}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteSitecoreDeployment(string name)
        {
            var args = await _unInstallPipeline.RunAsync(new UnInstallArgs { Name = name }).ConfigureAwait(false);
            return Request.CreateResponse(args.WasDeleted ? HttpStatusCode.OK : HttpStatusCode.Conflict);
        }
    }
}
