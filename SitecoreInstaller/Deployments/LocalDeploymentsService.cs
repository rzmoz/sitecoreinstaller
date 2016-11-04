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

            var args = new InstallLocalArgs { Info = info };
            return _deploymentsScheduler.TryStart(info.Name, _installLocalPipeline, args);
        }

        public bool TryDeleteDeployment(string name)
        {
            var args = new UnInstallLocalArgs { Info = { Name = name } };
            return _deploymentsScheduler.TryStart(name, _unInstallLocalPipeline, args);
        }

        public DeploymentStatus GetStatus(string name)
        {
            if (_deploymentsScheduler.IsRunning(name))
                return DeploymentStatus.InProgress;
            var dir = GetDeploymentDir(name);
            if (dir.Exists() == false)
                return DeploymentStatus.NotFound;

            var info = dir.GetDeploymentInfo();
            return info?.Done == true ?
                DeploymentStatus.Success :
                DeploymentStatus.Failed;
        }

        public void SaveDeploymentInfo(DeploymentInfo info, DeploymentDir deploymentDir)
        {
            var infoJson = JsonConvert.SerializeObject(info, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,

            });
            infoJson.WriteAllText(deploymentDir.DeploymentInfo, true);
            _logger.Debug($"Deployment info for {deploymentDir.Name}:\r\n{infoJson}");
            _logger.Trace($"Deployment info for {deploymentDir.Name} saved to {deploymentDir.DeploymentInfo}");
        }

        public IEnumerable<DeploymentInfo> GetDeploymentInfos()
        {
            foreach (var dir in Root.EnumerateDirectories())
                yield return GetDeploymentInfo(dir.Name);
        }

        public DeploymentInfo GetDeploymentInfo(string name)
        {
            return GetDeploymentDir(name)?.GetDeploymentInfo();
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
