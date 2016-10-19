using System;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Website
{
    public class WebsiteService : IPreflightCheck
    {
        private readonly ILogger _logger;

        public WebsiteService(EnvironmentSettings environmentSettings)
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
            _logger.Trace($"{nameof(WebsiteService)} initialized to: {Root.FullName}");
        }

        public void InitProjectDir(string siteName)
        {
            var projectDir = new ProjectDir(Root.Add(siteName));
            projectDir.Databases.CreateIfNotExists();
            projectDir.Website.App_Config.CreateIfNotExists();
            projectDir.Website.App_Data.CreateIfNotExists();
            projectDir.Website.Temp.CreateIfNotExists();
        }

        public bool DeleteProjectDir(string siteName)
        {
            var projectDir = new ProjectDir(Root.Add(siteName));

            var success = Repeat.Task(() => projectDir.DeleteIfExists())
                .WithOptions(o =>
                {
                    o.RetryDelay = 500.MilliSeconds();
                    o.MaxTries = 10;


                })
                .Until(() => projectDir.Exists() == false);

            if (success)
                _logger.Trace($"Project dir successfully deleted: {projectDir.FullName}");
            else
                _logger.Error($"Failed to delete project dir: {projectDir.FullName}");

            return success;
        }

        public PreflightCheckResult Assert()
        {
            Init();
            return new PreflightCheckResult(issues =>
            {
                if (Root.Exists())
                    _logger.Debug($"Sites root dir found at: {Root.FullName}");
                else
                    issues.Add($"Sites root dir not found at: {Root.FullName}");
            });
        }
    }
}
