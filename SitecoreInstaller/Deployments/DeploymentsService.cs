﻿using System;
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

        public void Init()
        {
            if (Root.Exists())
                return;
            Root.CreateIfNotExists();
            _logger.Trace($"{nameof(DeploymentsService)} initialized to: {Root.FullName}");
        }

        public void CopyModules(IEnumerable<Module> modules, string deploymentName)
        {
            var deploymentDir = new DeploymentDir(Root.Add(deploymentName));

            Parallel.ForEach(modules.Where(m => m.Path.IsFolder == false), m =>
            {
                _logger.Debug($"Copying module {m.Name} for {deploymentName}...");
                m.Path.ToFile().CopyTo(deploymentDir.Website.App_Data.Packages);
                _logger.Debug($"Module {m.Name} for {deploymentName} copied to {deploymentDir.Website.App_Data.Packages.ToFile(m.Name)}");
            });
        }

        public void CopyLicenseFile(License license, string deploymentName)
        {
            var deploymentDir = new DeploymentDir(Root.Add(deploymentName));
            _logger.Debug($"Copying license file {license.Name} for {deploymentName}...");
            license.Path.CopyTo(deploymentDir.Website.App_Data.LicenseXml);
            _logger.Debug($"License file for {deploymentName} copied to {deploymentDir.Website.App_Data.LicenseXml}");
        }
        public void CopySitecore(Sitecore sitecore, string deploymentName)
        {
            var deploymentDir = new DeploymentDir(Root.Add(deploymentName));
            _logger.Debug($"Copying {sitecore.Name} for {deploymentName}...");
            Parallel.Invoke(() =>
            {
                //copy sitecore
                _logger.Debug($"Copying {sitecore.Name} for {deploymentName}");
                sitecore.Website.CopyTo(deploymentDir.Website, includeSubfolders: true);
                _logger.Trace($"Sitecore {sitecore.Name} copied to {deploymentDir.Website}");
            }, () =>
             {
                 //copy databases
                 _logger.Debug($"Copying Databases for {deploymentName}");
                 sitecore.Databases.CopyTo(deploymentDir.Databases, includeSubfolders: true);
                 FixReportingDatabaseFileNames(deploymentDir);
                 _logger.Debug($"Databases for {deploymentName} copied to {deploymentDir.Databases}");
             }, () =>
             {
                 //copy data
                 _logger.Debug($"Copying Data for {deploymentName}");
                 sitecore.Data.CopyTo(deploymentDir.Website.App_Data, includeSubfolders: true);
                 _logger.Debug($"Data for {deploymentName} copied to {deploymentDir.Website.App_Data}");
             });

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
                    _logger.Debug($"Deployments root dir found at: {Root.FullName}");
                else
                    issues.Add($"Deployments root dir not found at: {Root.FullName}");
            });
        }
    }
}
