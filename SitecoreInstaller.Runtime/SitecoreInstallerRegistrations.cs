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
using SitecoreInstaller.PreflightChecks;
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
            //don't bother register this as preflight since it MUST be initialized before everything else - so
            //also, must be registered as single instance to ensure loaded values are persisted
            builder.RegisterType<EnvironmentSettings>().AsSelf().SingleInstance();
            builder.Register(c => builder.Container.Resolve<EnvironmentSettings>().BasicSettings).AsSelf();
            builder.Register(c => builder.Container.Resolve<EnvironmentSettings>().AdvancedSettings).AsSelf();

            //web server
            builder.RegisterType<HostFile>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<IisManagementService>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<IisApplicationSettingsFactory>().AsSelf().SingleInstance();

            //databases
            builder.RegisterType<ConnectionStringsConfigFormatter>().AsSelf().SingleInstance();
            builder.RegisterType<SqlDbService>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<MongoDbService>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //build lib
            builder.RegisterType<LocalBuildLibrary>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //web site
            builder.RegisterType<WebsiteService>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //deployments 
            builder.RegisterType<LocalDeploymentsService>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //pipelines
            builder.Register(c => new InstallLocalPipeline(builder.Container)).OnActivated(e => InitPipeline(e.Instance)).AsSelf();
            builder.Register(c => new UnInstallLocalPipeline(builder.Container)).OnActivated(e => InitPipeline(e.Instance)).AsSelf();
        }

        private void InitPipeline<T>(Pipeline<T> pipeline) where T : new()
        {
            pipeline.Started += args =>
            {
                var logger = LogManager.GetLogger(args.Name);
                logger.Trace($"{args.Name} started..");
            };
            pipeline.Ended += args =>
            {
                var logger = LogManager.GetLogger(args.Name);
                var msg = $"{args.Name} ended";
                if (args.Exception == null)
                    msg += " successfully";
                else
                    msg += " with errors";

                if (args.WasCancelled)
                    msg += " and was cancelled";

                logger.Trace(msg);
            };
        }
    }
}
