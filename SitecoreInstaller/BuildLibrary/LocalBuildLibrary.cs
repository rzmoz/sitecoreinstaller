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
            return Modules.EnumerateDirectories().Select(dir => new Module(dir));
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
            return (Module)Get(() => new Module(Modules.Add(name)));
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

        private BuildLibraryResource Get(Func<BuildLibraryResource> getRes)
        {
            var res = getRes();
            return res.Path.Exists() ? res : null;
        }
    }
}