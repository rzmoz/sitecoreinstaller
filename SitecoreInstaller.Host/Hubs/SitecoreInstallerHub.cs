using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Host.Hubs
{
    [HubName("siHub")]
    public class SitecoreInstallerHub : Hub
    {
        private readonly LocalDeploymentsService _localDeploymentsService;
        private readonly LocalBuildLibrary _localBuildLibrary;


        public SitecoreInstallerHub(LocalDeploymentsService localDeploymentsService, LocalBuildLibrary localBuildLibrary)
        {
            _localDeploymentsService = localDeploymentsService;
            _localBuildLibrary = localBuildLibrary;
        }

        public void Init()
        {
            EventQueue.Attach("SiHub", dto => { Clients.All.hello(dto.Data); });

            Task.Run(async () =>
            {
                while (true)
                {
                    Clients.All.updateLocalDeploymentsCount(_localDeploymentsService.LoadDeploymentInfos().Count());
                    Clients.All.updateDeployments(_localDeploymentsService.LoadDeploymentInfos());
                    Clients.All.updateSitecores(_localBuildLibrary.GetSitecores().Select(s => s.Name).OrderByDescending(s => s));
                    Clients.All.updateLicenses(_localBuildLibrary.GetLicenses().Select(l => LicenseInfo.Load(l.Path.ToFile())));
                    Clients.All.updateModules(_localBuildLibrary.GetModules());
                    await Task.Delay(3.Seconds()).ConfigureAwait(false);
                }
            });
        }
    }
}
