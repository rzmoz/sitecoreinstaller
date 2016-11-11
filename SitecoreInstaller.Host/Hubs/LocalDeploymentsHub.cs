using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Host.Hubs
{
    public class LocalDeploymentsHub : Hub
    {
        private readonly LocalDeploymentsService _localDeploymentsService;

        public LocalDeploymentsHub(LocalDeploymentsService localDeploymentsService)
        {
            _localDeploymentsService = localDeploymentsService;
        }

        public void GetAllInfo()
        {
            Clients.All.GetAllInfo(JsonConvert.SerializeObject(_localDeploymentsService.LoadDeploymentInfos()));
        }
    }
}
