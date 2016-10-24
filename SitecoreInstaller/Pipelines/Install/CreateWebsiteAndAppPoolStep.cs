﻿using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.Install
{
    public class CreateWebsiteAndAppPoolStep : PipelineStep<InstallArgs>
    {
        private readonly IisManagementService _iisManagementService;

        public CreateWebsiteAndAppPoolStep(IisManagementService iisManagementService)
        {
            _iisManagementService = iisManagementService;
        }

        protected override Task RunImpAsync(InstallArgs args, CancellationToken ct)
        {
            _iisManagementService.CreateApplication(args.Name, args.DeploymentDir);
            return Task.CompletedTask;
        }
    }
}