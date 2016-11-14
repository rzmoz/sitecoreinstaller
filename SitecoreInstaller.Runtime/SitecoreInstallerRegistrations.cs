using System.Linq;
using Autofac;
using DotNet.Basics.Ioc;
using DotNet.Basics.Rest;
using DotNet.Basics.Tasks.Pipelines;
using NLog;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Databases;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Pipelines.LocalInstall;
using SitecoreInstaller.Pipelines.LocalUnInstall;
using SitecoreInstaller.Website;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Runtime
{
    public class SitecoreInstallerRegistrations : IIocRegistrations
    {
        public void RegisterIn(IocBuilder builder)
        {
            builder.RegisterType<RestClient>().As<IRestClient>();

            //environment
            //don't register this as preflight since it MUST be initialized before everything else
            //also, MUST be registered as single instance to ensure loaded values are persisted
            builder.RegisterType<EnvironmentSettings>().AsSelf().SingleInstance();
            builder.Register(c => builder.Container.Resolve<EnvironmentSettings>().BasicSettings).AsSelf();
            builder.Register(c => builder.Container.Resolve<EnvironmentSettings>().AdvancedSettings).AsSelf();

            //web server
            builder.RegisterType<HostFile>().AsSelf().As<IPreflightCheck>();
            builder.RegisterType<IisManagementService>().AsSelf().As<IPreflightCheck>();
            builder.RegisterType<IisApplicationSettingsFactory>().AsSelf();

            //databases
            builder.RegisterType<ConnectionStringsConfigFormatter>().AsSelf();
            //MUST be single instance to ensure vaules are persisted
            builder.RegisterType<SqlDbService>().AsSelf().As<IPreflightCheck>().SingleInstance();
            builder.RegisterType<MongoDbService>().AsSelf().As<IPreflightCheck>().SingleInstance();

            //build lib
            builder.RegisterType<LocalBuildLibrary>().AsSelf().As<IPreflightCheck>();

            //web site
            builder.RegisterType<WebsiteService>().AsSelf().As<IPreflightCheck>();

            //deployments 
            builder.RegisterType<LocalDeploymentsService>().AsSelf().As<IPreflightCheck>();

            //pipelines
            builder.Register(c => new InstallLocalPipeline(() => builder.Container)).OnActivated(e => InitPipeline(e.Instance)).AsSelf().As<IPreflightCheck>();
            builder.Register(c => new UnInstallLocalPipeline(() => builder.Container)).OnActivated(e => InitPipeline(e.Instance)).AsSelf().As<IPreflightCheck>();
        }

        private void InitPipeline<T>(Pipeline<T> pipeline) where T : class, new()
        {
            pipeline.Started += args =>
            {
                var logger = LogManager.GetLogger(args.Name);
                logger.Trace($"{args.Name} started..");
            };
            pipeline.Ended += args =>
            {
                var logger = LogManager.GetLogger(args.Name);
                var msg = $"{args.Name}";

                if (args.Issues.Any())
                {
                    msg += " Issues:";
                    foreach (var issue in args.Issues)
                        msg += $"\r\n{issue}";
                }

                if (args.Exceptions.Any())
                    logger.Error(msg);
                else
                    logger.Trace(msg);
            };
        }
    }
}
