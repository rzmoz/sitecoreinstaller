using Microsoft.AspNetCore.Hosting;

namespace SitecoreInstaller.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(o => o.AddServerHeader = false)
                .UseUrls("http://0.0.0.0:13371")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
