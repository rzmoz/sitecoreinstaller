using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Basics.IO;
using DotNet.Basics.NLog;
using DotNet.Basics.Tasks;

namespace SitecoreInstaller.BuildLibrary
{
    public class DiskBuildLibrary : IPreflightCheck
    {
        public DiskBuildLibrary(EnvironmentSettings environmentSettings)
        {
            if (environmentSettings == null) throw new ArgumentNullException(nameof(environmentSettings));
            Root = environmentSettings.AdvancedSettings.BuildLibraryRootDir.ToDir();
            Sitecores = Root.Add(nameof(BuildLibraryInfo.Sitecores));
            Licenses = Root.Add(nameof(BuildLibraryInfo.Licenses));
            Modules = Root.Add(nameof(BuildLibraryInfo.Modules));
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
            this.NLog().Trace($"{nameof(DiskBuildLibrary)} initialized to: {Root.FullName}");
        }

        public BuildLibraryInfo GetAll()
        {
            return new BuildLibraryInfo
            {
                Sitecores = GetSitecores().OrderByDescending(s => s.Name).ToArray(),
                Licenses = GetLicenses().Select(l => l.GetInfo()).OrderByDescending(s => s.Expiration).ToArray(),
                Modules = GetModules().ToArray(),
            };
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

        public TaskResult Assert()
        {
            Init();
            return new TaskResult(issues =>
            {
                if (Root.Exists())
                    this.NLog().Trace($"{nameof(DiskBuildLibrary)} found at: {Root.FullName}");
                else
                    issues.Add($"{nameof(DiskBuildLibrary)} not found at: {Root.FullName}");
            });
        }

        private BuildLibraryResource Get(Func<BuildLibraryResource> getRes)
        {
            var res = getRes();
            return res.Path.Exists() ? res : null;
        }
    }
}