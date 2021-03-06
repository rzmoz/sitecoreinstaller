﻿using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.WebServer;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class CreateWebsiteAndAppPoolStep : PipelineStep<InstallLocalArgs>
    {
        private readonly IisManagementService _iisManagementService;

        public CreateWebsiteAndAppPoolStep(IisManagementService iisManagementService)
        {
            _iisManagementService = iisManagementService;
        }

        protected override Task RunImpAsync(InstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            _iisManagementService.CreateApplication(args.Info.Name, args.Info.Url, args.DeploymentDir);
            return Task.CompletedTask;
        }
    }
}
