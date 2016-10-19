using System;
using System.Security.AccessControl;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using NLog;
using SitecoreInstaller.PreflightChecks;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Deployments
{
    public class DeploymentsService : IPreflightCheck
    {
        private readonly ILogger _logger;

        public DeploymentsService(EnvironmentSettings environmentSettings)
        {
            if (environmentSettings == null) throw new ArgumentNullException(nameof(environmentSettings));
            Root = environmentSettings.SitesRootDir.ToDir();
            _logger = LogManager.GetLogger(nameof(WebsiteService));
        }

        public DirPath Root { get; }

        public void Init()
        {
            if (Root.Exists())
                return;
            Root.CreateIfNotExists();
            _logger.Trace($"{nameof(DeploymentsService)} initialized to: {Root.FullName}");
        }

        public void InitDeploymentDir(string siteName)
        {
            var projectDir = new DeploymentDir(Root.Add(siteName));
            projectDir.Databases.CreateIfNotExists();
            projectDir.Website.App_Config.CreateIfNotExists();
            projectDir.Website.App_Data.CreateIfNotExists();
            projectDir.Website.Temp.CreateIfNotExists();
            projectDir.GrantAccess("everyone", FileSystemRights.FullControl);
        }

        public bool DeleteDeploymentDir(string siteName)
        {
            var deploymentDir = new DeploymentDir(Root.Add(siteName));

            var success = Repeat.Task(() => deploymentDir.DeleteIfExists())
                .WithOptions(o =>
                {
                    o.RetryDelay = 500.MilliSeconds();
                    o.MaxTries = 10;
                })
                .Until(() => deploymentDir.Exists() == false);

            if (success)
                _logger.Trace($"Deployment dir successfully deleted: {deploymentDir.FullName}");
            else
                _logger.Error($"Failed to delete Deployment dir: {deploymentDir.FullName}");

            return success;
        }

        public PreflightCheckResult Assert()
        {
            Init();
            return new PreflightCheckResult(issues =>
            {
                if (Root.Exists())
                    _logger.Debug($"Deployments root dir found at: {Root.FullName}");
                else
                    issues.Add($"Deployments root dir not found at: {Root.FullName}");
            });
        }
    }
}
