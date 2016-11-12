using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SitecoreInstaller.Host.Hubs
{
    [HubName("siHub")]
    public class SitecoreInstallerHub : Hub
    {
        public void Init()
        {
            EventQueue.Attach(new EventWorker("SiHub", dto =>
            {
                Clients.All.hello(dto.Data);
            }));

            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1.Seconds()).ConfigureAwait(false);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
