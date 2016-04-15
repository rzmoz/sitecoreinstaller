using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class IOBuildLibrary : IBuildLibrary
    {
        private readonly DirectoryInfo _rootdir;
        private const string _sitecoresFolderName = "Sitecores";
        private const string _licensesFoldeName = "Licenses";
        private const string _modulesFolderName = "Modules";

        public IOBuildLibrary(DirectoryInfo rootdir = null)
        {
            var userDir = Environment.GetEnvironmentVariable("HOMEPATH").ToDir();
            _rootdir = rootdir ?? userDir.ToDir("BuildLibrary");
        }

        public IBuildLibraryResource Get(string name, BuildLibraryType buildLibraryType)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            string typeFolderName;
            switch (buildLibraryType)
            {
                case BuildLibraryType.LicenseFile:
                    typeFolderName = _licensesFoldeName;
                    break;
                case BuildLibraryType.Module:
                    typeFolderName = _modulesFolderName;
                    break;
                case BuildLibraryType.Sitecore:
                    typeFolderName = _sitecoresFolderName;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Build library type: {buildLibraryType} not recognized");
            }
            //help user
            name = name.Trim(' ');
            if (char.IsNumber(name[0]))
                name = $"Sitecore {name}";//append sitecore if only version is provided

            //we look for dirs first
            DirectoryInfo lookingForDir = _rootdir.ToDir(typeFolderName, name);
            if (lookingForDir.Exists())
                return new BuildLibraryDirResource(lookingForDir, buildLibraryType);
            FileInfo lookingForFile = _rootdir.ToFile(typeFolderName, name + ".zip");
            if (lookingForFile.Exists())
                return new BuildLibraryFileResource(lookingForFile, buildLibraryType);
            return null;//return nul if nothing found
        }

        public IBuildLibraryResource GetSitecore(string name)
        {
            return Get(name, BuildLibraryType.Sitecore);
        }

        public IBuildLibraryResource GetLicense(string name)
        {
            return Get(name, BuildLibraryType.LicenseFile);
        }

        public IBuildLibraryResource GetModule(string name)
        {
            return Get(name, BuildLibraryType.Module);
        }

        public IEnumerable<IBuildLibraryResource> Get(string[] names, BuildLibraryType buildLibraryType)
        {
            return names.Select(name => Get(name, buildLibraryType)).Where(res => res != null);
        }

        public IEnumerable<IBuildLibraryResource> GetSitecores(params string[] names)
        {
            return Get(names, BuildLibraryType.Sitecore);
        }

        public IEnumerable<IBuildLibraryResource> GetLicenses(params string[] names)
        {
            return Get(names, BuildLibraryType.LicenseFile);
        }

        public IEnumerable<IBuildLibraryResource> GetModules(params string[] names)
        {
            return Get(names, BuildLibraryType.Module);
        }
    }
}
