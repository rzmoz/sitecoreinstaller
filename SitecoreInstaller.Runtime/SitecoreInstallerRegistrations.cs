﻿using System;
using Autofac;
using DotNet.Basics.Ioc;
using DotNet.Basics.Tasks.Pipelines;
using NLog;
using SitecoreInstaller.BuildLibrary;
using SitecoreInstaller.Deployments;
using SitecoreInstaller.Pipelines.Install;
using SitecoreInstaller.Pipelines.UnInstall;
using SitecoreInstaller.PreflightChecks;
using SitecoreInstaller.Website;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Runtime
{
    public class SitecoreInstallerRegistrations : IIocRegistrations
    {
        public void RegisterIn(IocBuilder builder)
        {
            //environment
            builder.RegisterType<EnvironmentSettings>().AsSelf().SingleInstance();

            //web server
            builder.RegisterType<HostFile>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<IisManagementService>().As<IPreflightCheck>().AsSelf().SingleInstance();
            builder.RegisterType<IisApplicationSettingsFactory>().AsSelf().SingleInstance();

            //build lib
            builder.RegisterType<LocalBuildLibrary>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //web site
            builder.RegisterType<WebsiteService>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //deployments 
            builder.RegisterType<DeploymentsService>().As<IPreflightCheck>().AsSelf().SingleInstance();

            //pipelines
            builder.Register(c => new InstallPipeline(builder.Container))
                .OnActivated(e => InitPipeline(e.Instance)).AsSelf();
            builder.Register(c => new UnInstallPipeline(builder.Container))
                .OnActivated(e => InitPipeline(e.Instance)).AsSelf();
        }

        private void InitPipeline<T>(Pipeline<T> pipeline) where T : EventArgs, new()
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
