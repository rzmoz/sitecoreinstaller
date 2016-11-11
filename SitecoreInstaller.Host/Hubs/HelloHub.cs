using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using Microsoft.AspNet.SignalR;

namespace SitecoreInstaller.Host.Hubs
{
    public class HelloHub : Hub
    {
        public void Init()
        {
            EventQueue.Attach(new EventWorker("HelloHub", dto =>
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
