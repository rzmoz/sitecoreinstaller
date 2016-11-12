using System.Linq;
using Autofac;
using DotNet.Basics.Ioc;
using DotNet.Basics.Rest;
using DotNet.Basics.Tasks.Pipelines;
using NLog;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Databases;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Pipelines;
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
            //don't register this as preflight since it MUST be initialized before everything else
            //also, MUST be registered as single instance to ensure loaded values are persisted
            builder.RegisterType<EnvironmentSettings>().AsSelf().SingleInstance();
            builder.Register(c => builder.Container.Resolve<EnvironmentSettings>().BasicSettings).AsSelf();
            builder.Register(c => builder.Container.Resolve<EnvironmentSettings>().AdvancedSettings).AsSelf();

            //web server
            builder.RegisterType<HostFile>().As<IPreflightCheck>().AsSelf();
            builder.RegisterType<IisManagementService>().As<IPreflightCheck>().AsSelf();
            builder.RegisterType<IisApplicationSettingsFactory>().AsSelf();

            //databases
            builder.RegisterType<ConnectionStringsConfigFormatter>().AsSelf();
            //MUST be single instance to ensure vaules are persisted
            builder.RegisterType<SqlDbService>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<MongoDbService>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //build lib
            builder.RegisterType<LocalBuildLibrary>().As<IPreflightCheck>().AsSelf();

            //web site
            builder.RegisterType<WebsiteService>().As<IPreflightCheck>().AsSelf();

            //deployments 
            builder.RegisterType<LocalDeploymentsService>().As<IPreflightCheck>().AsSelf();

            //pipelines
            builder.RegisterGeneric(typeof(InitDeploymentDirStep<>)).AsSelf();
            builder.Register(c => new InstallLocalPipeline(builder.Container)).OnActivated(e => InitPipeline(e.Instance)).AsSelf();
            builder.Register(c => new UnInstallLocalPipeline(builder.Container)).OnActivated(e => InitPipeline(e.Instance)).AsSelf();
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

                if (args.WasCancelled)
                    msg += " was cancelled. ";

                if (args.Issues.Any())
                {
                    msg += " Issues:";
                    foreach (var issue in args.Issues)
                        msg +=$"\r\n{issue}";
                }

                if (args.Exception == null)
                    logger.Trace(msg);
                else
                    logger.Error(msg + "\r\n" + args.Exception.ToString());
            };
        }
    }
}
