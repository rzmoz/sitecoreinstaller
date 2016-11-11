using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using Microsoft.AspNet.SignalR;

namespace SitecoreInstaller.Host.Hubs
{
    public class HelloHub : Hub
    {
        public void Hello()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Clients.All.hello(DateTime.UtcNow.Ticks);
                    await Task.Delay(1.Seconds()).ConfigureAwait(false);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
