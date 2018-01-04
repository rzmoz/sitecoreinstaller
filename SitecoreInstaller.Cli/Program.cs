using System;
using System.Threading.Tasks;
using SitecoreInstaller.App;

namespace SitecoreInstaller.Cli
{
    class Program
    {
        public static Task<int> Main(string[] args)
        {
            var appSettings = new ApplicationSettings();
            Console.WriteLine(appSettings.LibraryRootDir);

            var applicationInitializer = new ApplicationInitializer(null);
            applicationInitializer.InitRegistrations(appSettings, builder =>
            {
                
            });

            return Task.FromResult(0);
        }
    }
}
