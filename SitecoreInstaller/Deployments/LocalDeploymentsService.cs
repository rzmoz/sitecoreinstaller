using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using DotNet.Basics.IO;
using Newtonsoft.Json;
using NLog;
using SitecoreInstaller.Pipelines.LocalInstall;
using SitecoreInstaller.Pipelines.LocalUnInstall;
using SitecoreInstaller.PreflightChecks;
using SitecoreInstaller.Website;

namespace SitecoreInstaller.Deployments
{
    public class LocalDeploymentsService : IPreflightCheck
    {
        private readonly ILogger _logger;

        private readonly DeploymentsScheduler _deploymentsScheduler;
        private readonly InstallLocalPipeline _installLocalPipeline;
        private readonly UnInstallLocalPipeline _unInstallLocalPipeline;

        public LocalDeploymentsService(EnvironmentSettings environmentSettings, InstallLocalPipeline installLocalPipeline, UnInstallLocalPipeline unInstallLocalPipeline)
        {
            if (environmentSettings == null) throw new ArgumentNullException(nameof(environmentSettings));
            if (installLocalPipeline == null) throw new ArgumentNullException(nameof(installLocalPipeline));
            if (unInstallLocalPipeline == null) throw new ArgumentNullException(nameof(unInstallLocalPipeline));
            _deploymentsScheduler = new DeploymentsScheduler();
            _installLocalPipeline = installLocalPipeline;
            _unInstallLocalPipeline = unInstallLocalPipeline;
            _logger = LogManager.GetLogger(nameof(WebsiteService));
            Root = environmentSettings.AdvancedSettings.SitesRootDir.ToDir();
        }

        public DirPath Root { get; }

        public bool TryStartNewDeployment(DeploymentInfo info)
        {
            if (string.IsNullOrWhiteSpace(info.Name) ||
                string.IsNullOrWhiteSpace(info.Sitecore) ||
                string.IsNullOrWhiteSpace(info.License))
                throw new ArgumentException($"Name, Sitecore and License must be set. Was: {JsonConvert.SerializeObject(info)}");


            var args = new InstallLocalArgs { CurrentTaskName = "Installing", Info = info };
            return _deploymentsScheduler.TryStart(info.Name, _installLocalPipeline, args);
        }

        public bool TryDeleteDeployment(string name)
        {
            var args = new UnInstallLocalArgs { CurrentTaskName = "Deleting", Info = { Name = name } };
            return _deploymentsScheduler.TryStart(name, _unInstallLocalPipeline, args);
        }

        public IEnumerable<DeploymentInfo> LoadDeploymentInfos()
        {
            foreach (var dir in Root.EnumerateDirectories())
                yield return LoadDeploymentInfo(dir.Name);
        }

        public DeploymentInfo LoadDeploymentInfo(string name)
        {
            var dDir = GetDeploymentDir(name);
            var di = dDir?.LoadDeploymentInfo();
            if (di == null)
                return null;

            if (_deploymentsScheduler.IsRunning(di.Name) || di.Task.Status != DeploymentStatus.InProgress)
                return di;
            di.Task.Status = DeploymentStatus.Failed;
            dDir.SaveDeploymentInfo(di);
            return di;
        }

        public DeploymentDir GetDeploymentDir(string deploymentName, bool initialize = false)
        {
            var deploymentDir = new DeploymentDir(Root.Add(deploymentName));
            if (initialize)
            {
                deploymentDir.Databases.CreateIfNotExists();
                deploymentDir.Website.App_Config.Include.CreateIfNotExists();
                deploymentDir.Website.App_Data.Packages.CreateIfNotExists();
                deploymentDir.Website.Temp.RuntimeServices.CreateIfNotExists();
                deploymentDir.Website.Bin.CreateIfNotExists();
                deploymentDir.GrantAccess("everyone", FileSystemRights.FullControl);
            }
            return deploymentDir;
        }

        public PreflightCheckResult Assert()
        {
            return new PreflightCheckResult(issues =>
            {
                if (Root.Exists())
                    _logger.Trace($"Deployments root dir found at: {Root.FullName}");
                else
                {
                    Root.CreateIfNotExists();
                    _logger.Trace($"{nameof(LocalDeploymentsService)} initialized to: {Root.FullName}");
                }
            });
        }
    }
}
