using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.Diagnostics.Contracts;
    using System.IO;

    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.IO;

    public class WindowsZipAndFoldersSourceEntryRepository : WindowsSourceEntryRepository
    {
        private readonly IList<Func<string, BuildLibraryResource>> _getSourceEntryFuncs;

        public WindowsZipAndFoldersSourceEntryRepository(DirectoryInfo root, BuildLibraryMode buildLibraryMode)
            : base(root, buildLibraryMode)
        {
            _getSourceEntryFuncs = new List<Func<string, BuildLibraryResource>>(2);
            SetGetSourceEntry();
        }

        private void SetGetSourceEntry()
        {
            _getSourceEntryFuncs.Clear();
            switch (Mode)
            {
                case BuildLibraryMode.Local:
                    //check directories first - then zip files
                    _getSourceEntryFuncs.Add(GetDirectory);
                    _getSourceEntryFuncs.Add(GetZipFile);
                    break;
                case BuildLibraryMode.External:
                    //check zip files first - then directories
                    _getSourceEntryFuncs.Add(GetZipFile);
                    _getSourceEntryFuncs.Add(GetDirectory);
                    break;
            }
        }

        public override void Update(string sourceName)
        {
            Log.As.Debug("Updating source entry repository '{0}'", sourceName);

            Entries.Clear();
            if (Directory.Exists(Root.FullName) == false)
                return;

            foreach (var dir in Root.GetDirectories())
            {
                Log.As.Debug("Adding '{0}' from directory", dir.FullName);
                Entries.Add(dir.Name.ToLower(), new SourceEntry(dir.Name, sourceName));
            }

            foreach (var zipFile in Root.GetFiles("*.zip"))
            {
                var cleanedName = zipFile.NameWithoutExtension();
                if (Entries.ContainsKey(cleanedName.ToLower()))
                    continue;
                Log.As.Debug("Adding '{0}' from zip file", cleanedName);
                Entries.Add(cleanedName.ToLower(), new SourceEntry(cleanedName, sourceName));
            }
        }

        public override BuildLibraryResource Get(SourceEntry sourceEntry)
        {
            Root.CreateIfNotExists();

            foreach (var getSourceEntryFunc in _getSourceEntryFuncs)
            {
                var buildLibraryResource = getSourceEntryFunc(sourceEntry.Key);
                if (buildLibraryResource != null)
                    return buildLibraryResource;
            }
            return null;
        }

        private BuildLibraryResource GetZipFile(string sourceEntryKey)
        {
            var filePattern = sourceEntryKey + ".zip";
            if (Root.GetFiles(filePattern).Any())
                return new BuildLibraryFile(Root.GetFiles(filePattern).First(), Mode);
            return null;
        }
        private BuildLibraryResource GetDirectory(string sourceEntryKey)
        {
            if (Root.GetDirectories(sourceEntryKey).Any())
                return new BuildLibraryDirectory(Root.GetDirectories(sourceEntryKey).First(), Mode);
            return null;
        }
    }
}
