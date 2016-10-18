using System;
using System.Linq;
using Microsoft.Owin.Hosting;
using NLog;

namespace SitecoreInstaller.Hosting
{
    class Program
    {
        private const string _defaultPort = "7919";

        static void Main(string[] args)
        {
            int portNumber = int.Parse(args.FirstOrDefault() ?? _defaultPort);

            string baseAddress = $"http://localhost:{portNumber}/";

            var @namespace = typeof(Program).Namespace;

            using (WebApp.Start<WebApiInit>(url: baseAddress))
            {
                var logger = LogManager.GetLogger(@namespace);
                logger.Info($"{@namespace} is listening on port {portNumber}...");
                Console.ReadKey();
            }
        }
    }
}
