using System;
using DotNet.Basics.Tasks.Pipelines;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace SitecoreInstaller.Host
{
    public class HostInit
    {
        public HostInit(Func<ILogger> initLogger)
        {
            if (initLogger == null) throw new ArgumentNullException(nameof(initLogger));
            Logger = initLogger();
            if (Logger == null)
                throw new ArgumentException("initLogger() returned null. Must return instance");
        }

        public ILogger Logger { get; }

        public void InitFileServer(IAppBuilder app)
        {
            //app.NLog().Debug("Initializing File Server...");

            //file server
            app.UseFileServer(new FileServerOptions
            {
                FileSystem = new PhysicalFileSystem("Client"),
                DefaultFilesOptions = { DefaultFileNames = { "index.html" } }
            });
            //app.NLog().Debug("File Server initialized");
        }
        public void InitPipeline<T>(Pipeline<T> pipeline) where T : class, new()
        {
            /*var logger = pipeline.NLog();

            pipeline.Started += args =>
            {
                logger.Trace($"{args.Name} started..");
            };
            pipeline.Ended += args =>
            {
                var msg = $"{args.Name} ended";
                if (args.Issues.Any())
                    msg += " with issues:";

                logger.Trace(msg);
                if (args.Issues.Any())
                {
                    foreach (var issue in args.Issues)
                    {
                        logger.Error($"\r\n{issue.Message}\r\n\r\n");
                        if (issue.Exception != null)
                            logger.Debug($"{issue.Exception}\r\n\r\n");
                    }
                }
            };*/
        }
    }
}
