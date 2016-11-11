using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace SitecoreInstaller.Host.Hubs
{
    public class BuildLibraryHub : Hub
    {
        public void GetModules()
        {
            var modules = new[] { "231123123", "2342342", "234234234234" };

            Clients.All.getModules(JsonConvert.SerializeObject(modules));
        }
    }
}
