using System;
using System.Collections.Generic;
using System.Linq;
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
        public DeploymentDir GetDeploymentDir(string deploymentName) => new DeploymentDir(Root.Add(deploymentName));

        public void Init()
        {
            if (Root.Exists())
                return;
            Root.CreateIfNotExists();
            _logger.Trace($"{nameof(DeploymentsService)} initialized to: {Root.FullName}");
        }

        public void CopyRuntimeServices(string deploymentName)
        {
            var runtimeServicesDir = GetDeploymentDir(deploymentName).Website.Temp.RuntimeServices;
            runtimeServicesDir.CreateIfNotExists();
            Parallel.Invoke(
                () => DeploymentsResources.AdminLogin.WriteAllText(runtimeServicesDir.AdminLogin),
                () => DeploymentsResources.DeserializeItems.WriteAllText(runtimeServicesDir.DeserializeItems),
                () => DeploymentsResources.InstallPackageService.WriteAllText(runtimeServicesDir.InstallPackageService),
                () => DeploymentsResources.InstallPackageStatusService.WriteAllText(runtimeServicesDir.InstallPackageStatusService),
                () => DeploymentsResources.PostInstallService.WriteAllText(runtimeServicesDir.PostInstallService),
                () => DeploymentsResources.PublishSite.WriteAllText(runtimeServicesDir.PublishSite));

            _logger.Trace($"Runtime services installed to {runtimeServicesDir }");
        }

        public void CopyModules(IEnumerable<Module> modules, string deploymentName)
        {
            var deploymentDir = GetDeploymentDir(deploymentName);
            modules = modules.ToList();

            //copy standalone sc modules
            Parallel.ForEach(modules.Where(m => m.Path.IsFolder == false), m =>
            {
                _logger.Debug($"Copying module {m.Name} for {deploymentName}...");
                m.Path.ToFile().CopyTo(deploymentDir.Website.App_Data.Packages);
                _logger.Debug($"Module {m.Name} for {deploymentName} copied to {deploymentDir.Website.App_Data.Packages.ToFile(m.Name)}");
            });

            foreach (var m in modules.Where(m => m.Path.IsFolder))
            {
                _logger.Debug($"Copying module {m.Name} for {deploymentName}...");
                //TODO: Coply custom module files
                _logger.Debug($"Module {m.Name} for {deploymentName} copied to {deploymentDir.Website}");
            }
        }

        public void CopyLicenseFile(License license, string deploymentName)
        {
            var deploymentDir = GetDeploymentDir(deploymentName);
            _logger.Debug($"Copying license file {license.Name} for {deploymentName}...");
            license.Path.ToFile().CopyTo(deploymentDir.Website.App_Data.LicenseXml);
            _logger.Debug($"License file for {deploymentName} copied to {deploymentDir.Website.App_Data.LicenseXml}");
        }

        public void CopySitecore(BuildLibrary.Sitecore sitecore, string deploymentName)
        {
            var deploymentDir = GetDeploymentDir(deploymentName);
            _logger.Debug($"Copying {sitecore.Name} for {deploymentName}...");
            Parallel.Invoke(() =>
            {
                //copy sitecore
                var target = deploymentDir.Website;
                _logger.Debug($"Copying Website for {deploymentName} to {target }");
                sitecore.Website.CopyTo(target, includeSubfolders: true);
                _logger.Trace($"Sitecore copied to {target }");
            }, () =>
             {
                 //copy databases
                 var target = deploymentDir.Databases;
                 _logger.Debug($"Copying Databases for {deploymentName} to {target }");
                 sitecore.Databases.CopyTo(target, includeSubfolders: true);
                 FixReportingDatabaseFileNames(deploymentDir);
                 _logger.Trace($"Databases copied to {target }");
             }, () =>
             {
                 //copy data
                 var target = deploymentDir.Website.App_Data;
                 _logger.Debug($"Copying Data for {deploymentName} to {target }");
                 sitecore.Data.CopyTo(target, includeSubfolders: true);
                 _logger.Trace($"Data copied to {target }");
             });

            _logger.Trace($"{sitecore.Name} for {deploymentName} copied");
        }

        public DeploymentDir InitDeploymentDir(string deploymentName)
        {
            var deploymentDir = GetDeploymentDir(deploymentName);
            deploymentDir.Databases.CreateIfNotExists();
            deploymentDir.Website.App_Config.CreateIfNotExists();
            deploymentDir.Website.App_Data.CreateIfNotExists();
            deploymentDir.Website.Temp.CreateIfNotExists();
            deploymentDir.GrantAccess("everyone", FileSystemRights.FullControl);
            return deploymentDir;
        }

        public bool DeleteDeploymentDir(DeploymentDir deploymentDir)
        {
            if (deploymentDir == null) throw new ArgumentNullException(nameof(deploymentDir));
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

        private void FixReportingDatabaseFileNames(DeploymentDir deploymentDir)
        {
            var analyticsFiles = deploymentDir.Databases.GetFiles("Sitecore.Analytics.*", true);

            foreach (var analyticsFile in analyticsFiles)
            {
                _logger.Trace($"Fixing reporting database filename for: {analyticsFile.FullName}");
                analyticsFile.MoveTo(analyticsFile.Directory.ToFile("Sitecore.Reporting" + analyticsFile.Extension));
            }
        }

        public PreflightCheckResult Assert()
        {
            Init();
            return new PreflightCheckResult(issues =>
            {
                if (Root.Exists())
                    _logger.Trace($"Deployments root dir found at: {Root.FullName}");
                else
                    issues.Add($"Deployments root dir not found at: {Root.FullName}");
            });
        }
    }
}
