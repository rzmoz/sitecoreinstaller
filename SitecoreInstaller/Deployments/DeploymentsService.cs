using System;
using System.Security.AccessControl;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using NLog;
using SitecoreInstaller.BuildLibrary;
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

        public void CopySitecore(Sitecore sitecore, string deploymentName)
        {
            var deploymentDir = new DeploymentDir(Root.Add(deploymentName));
            _logger.Trace($"Copying {sitecore.Name} for {deploymentName}...");

            //copy sitecore
            _logger.Trace($"Copying Sitecore {sitecore.Name} to {deploymentDir.Website}");
            sitecore.Website.CopyTo(deploymentDir.Website, includeSubfolders: true);
            _logger.Trace($"Sitecore {sitecore.Name} copied");

            //copy databases
            _logger.Trace($"Copying Databases for {deploymentName} to {deploymentDir.Databases}");
            sitecore.Databases.CopyTo(deploymentDir.Databases, includeSubfolders: true);
            _logger.Trace($"Databases for {deploymentName} copied");

            //copy data
            _logger.Trace($"Copying Data for {deploymentName} to {deploymentDir.Website.App_Data}");
            sitecore.Data.CopyTo(deploymentDir.Website.App_Data, includeSubfolders: true);
            _logger.Trace($"Data for {deploymentName} copied");

            _logger.Trace($"{sitecore.Name} for {deploymentName} copied");
        }

        public void InitDeploymentDir(string deploymentName)
        {
            var deploymentDir = new DeploymentDir(Root.Add(deploymentName));
            deploymentDir.Databases.CreateIfNotExists();
            deploymentDir.Website.App_Config.CreateIfNotExists();
            deploymentDir.Website.App_Data.CreateIfNotExists();
            deploymentDir.Website.Temp.CreateIfNotExists();
            deploymentDir.GrantAccess("everyone", FileSystemRights.FullControl);
        }

        public bool DeleteDeploymentDir(string deploymentName)
        {
            var deploymentDir = new DeploymentDir(Root.Add(deploymentName));

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
