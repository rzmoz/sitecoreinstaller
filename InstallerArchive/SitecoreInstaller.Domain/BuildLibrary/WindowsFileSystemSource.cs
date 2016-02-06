using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharp.Basics.IO;
using SitecoreInstaller.Framework.IOx;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class WindowsFileSystemSource : ISource
    {
        private readonly IDictionary<SourceType, WindowsSourceEntryRepository> _repositories;

        public WindowsFileSystemSource(string name)
        {
            _repositories = new Dictionary<SourceType, WindowsSourceEntryRepository>();
            Name = name;
        }

        public event EventHandler<EventArgs> Updating;
        public event EventHandler<EventArgs> Updated;

        public bool Enabled { get; set; }
        public string Name { get; private set; }

        public void SetMode(BuildLibraryMode buildLibraryMode)
        {
            UpdateLocalRepositories(buildLibraryMode);
        }

        public DirectoryInfo Getfolder(SourceType sourceType)
        {
            var repository = _repositories[sourceType];
            if (repository == null)
                return null;
            return repository.Root;
        }

        private string _parameters;
        public string Parameters
        {
            get { return _parameters; }
            set
            {
                if (value == null)
                    return;
                if (_parameters == null)
                    _parameters = value;
                else if (_parameters.Equals(value))
                    return;

                _parameters = value;
                UpdateLocalRepositories(BuildLibraryMode.External);
            }
        }

        private void UpdateLocalRepositories(BuildLibraryMode buildLibraryMode)
        {
            var buildLibraryFolders = new BuildLibraryFolders(Parameters);
            _repositories.Clear();
            _repositories.Add(SourceType.Sitecore, new WindowsZipAndFoldersSourceEntryRepository(buildLibraryFolders.Sitecore, buildLibraryMode, SourceType.Sitecore));
            _repositories.Add(SourceType.License, new WindowsLicenseFileSourceEntryRepository(buildLibraryFolders.Licenses, buildLibraryMode));
            _repositories.Add(SourceType.Module, new WindowsZipAndFoldersSourceEntryRepository(buildLibraryFolders.Modules, buildLibraryMode, SourceType.Module));
        }

        public bool Contains(string name, SourceType sourceType)
        {
            return _repositories[sourceType].ContainsKey(name);
        }

        public BuildLibraryResource Get(SourceEntry sourceEntry, SourceType sourceType)
        {
            return _repositories[sourceType].Get(sourceEntry);
        }
        public IEnumerable<BuildLibraryResource> Get(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
        {
            return from sourceEntry in sourceEntries select Get(sourceEntry, sourceType);
        }



        public BuildLibraryFile Add(string file, SourceType sourceType)
        {
            var buildLibraryResourceFactory = new BuildLibraryResourceFactory();
            var buildLibraryFile = buildLibraryResourceFactory.CreateFile(file);
            Add(buildLibraryFile, sourceType);
            Log.As.Info("{0} was succesfully added", buildLibraryFile.ToString());
            return buildLibraryFile;
        }

        public void Add(BuildLibraryFile buildLibraryFile, SourceType sourceType)
        {
            if (File.Exists(buildLibraryFile.File.FullName) == false)
                return;

            switch (sourceType)
            {
                case SourceType.License:
                case SourceType.Module:
                    buildLibraryFile.File.CopyTo(_repositories[sourceType].Root.CombineTo<DirectoryInfo>(buildLibraryFile.ToString().CleanIllegalFileNameChars()), true);
                    break;
                case SourceType.Sitecore:
                    buildLibraryFile.File.CopyTo(_repositories[sourceType].Root, true);
                    break;
            }
        }

        public void Delete(SourceEntry sourceEntry, SourceType sourceType)
        {
            var rootFolder = Getfolder(sourceType);
            if (rootFolder == null)
                return;

            var entry = Get(sourceEntry, sourceType);

            if (entry.FileSystemInfo is DirectoryInfo)
                (entry.FileSystemInfo as DirectoryInfo).DeleteWithLog();
            else
                entry.FileSystemInfo.Delete();
        }

        public void Delete(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
        {
            if (sourceEntries == null)
                return;

            foreach (var key in sourceEntries)
                Delete(key, sourceType);
        }

        public IEnumerable<SourceEntry> List(SourceType sourceType)
        {
            return _repositories[sourceType];
        }


        public void Update()
        {
            if (Updating != null)
                Updating(this, new EventArgs());

            foreach (var repoSource in _repositories.Values)
            {
                repoSource.Update(Name);
            }

            if (Updated != null)
                Updated(this, new EventArgs());
        }
    }
}

