using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Basics.IO;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.BuildLibrary
{
    public class LocalBuildLibrary : IPreflightCheck
    {
        private const string _sitecoresDirName = "Sitecores";
        private const string _licensesDirName = "Licenses";
        private const string _modulesDirName = "Modules";
        private readonly ILogger _logger;

        public LocalBuildLibrary(EnvironmentSettings environmentSettings)
        {
            if (environmentSettings == null) throw new ArgumentNullException(nameof(environmentSettings));
            Root = environmentSettings.BuildLibraryRootDir.ToDir();
            Sitecores = Root.Add(_sitecoresDirName);
            Licenses = Root.Add(_licensesDirName);
            Modules = Root.Add(_modulesDirName);
            _logger = LogManager.GetLogger(nameof(LocalBuildLibrary));
        }

        public DirPath Root { get; }
        public DirPath Sitecores { get; }
        public DirPath Modules { get; }
        public DirPath Licenses { get; }

        public void Init()
        {
            if (Root.Exists())
                return;

            Sitecores.CreateIfNotExists();
            Licenses.CreateIfNotExists();
            Modules.CreateIfNotExists();
            _logger.Trace($"{nameof(LocalBuildLibrary)} initialized to: {Root.FullName}");
        }

        public IEnumerable<Sitecore> GetSitecores()
        {
            return Sitecores.EnumerateDirectories().Select(dir => new Sitecore(dir));
        }

        public IEnumerable<License> GetLicenses()
        {
            return Licenses.EnumerateFiles().Select(file => new License(file));
        }

        public IEnumerable<Module> GetModules()
        {
            return Modules.EnumeratePaths().Select(path => new Module(path));
        }

        public Sitecore GetSitecore(string name)
        {
            return (Sitecore)Get(() => new Sitecore(Sitecores.Add(name)));
        }

        public License GetLicense(string name)
        {
            return (License)Get(() => new License(Licenses.ToFile(name)));
        }

        public Module GetModule(string name)
        {
            return (Module)Get(() => new Module(Modules.FullName.ToPath(name)));
        }

        public PreflightCheckResult Assert()
        {
            Init();
            return new PreflightCheckResult(issues =>
            {
                if (Root.Exists())
                    _logger.Trace($"{nameof(LocalBuildLibrary)} found at: {Root.FullName}");
                else
                    issues.Add($"{nameof(LocalBuildLibrary)} not found at: {Root.FullName}");
            });
        }

        private BuildLibraryResource Get(Func<BuildLibraryResource> getRes)
        {
            var res = getRes();
            return res.Path.Exists() ? res : null;
        }
    }
}