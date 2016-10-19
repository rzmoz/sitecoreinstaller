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

        public LocalBuildLibrary()
            : this(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).ToDir("SiBuildLibrary"))
        {
        }

        public LocalBuildLibrary(DirPath root)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));
            Root = root;
            Sitecores = root.Add(_sitecoresDirName);
            Licenses = root.Add(_licensesDirName);
            Modules = root.Add(_modulesDirName);
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

            Root.CreateIfNotExists();
            _logger.Trace($"{nameof(LocalBuildLibrary)} initialized to: {Root.FullName}");
        }

        public IReadOnlyCollection<Sitecore> GetSitecores()
        {
            return Sitecores.EnumerateDirectories().Select(dir => new Sitecore(dir)).ToList();
        }

        public IReadOnlyCollection<License> GetLicenses()
        {
            return Licenses.EnumerateDirectories().Select(dir => new License(dir)).ToList();
        }

        public IReadOnlyCollection<Module> GetModules()
        {
            return Modules.EnumerateDirectories().Select(dir => new Module(dir)).ToList();
        }

        public Sitecore GetSitecore(string name)
        {
            var res = new Sitecore(Sitecores.Add(name));
            return res.Dir.Exists() ? res : null;
        }

        public License GetLicense(string name)
        {
            var res = new License(Licenses.Add(name));
            return res.Dir.Exists() ? res : null;
        }

        public Module GetModule(string name)
        {
            var res = new Module(Modules.Add(name));
            return res.Dir.Exists() ? res : null;
        }

        public PreflightCheckResult Assert()
        {
            Init();
            return new PreflightCheckResult(issues =>
            {
                if (Root.Exists())
                    _logger.Debug($"{nameof(LocalBuildLibrary)} found at: {Root.FullName}");
                else
                    issues.Add($"{nameof(LocalBuildLibrary)} not found at: {Root.FullName}");
            });
        }
    }
}