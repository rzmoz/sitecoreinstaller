using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.IO;
    using System.Xml.Linq;

    using SitecoreInstaller.Framework.Diagnostics;

    public class WindowsLicenseFileSourceEntryRepository : WindowsSourceEntryRepository
    {
        public WindowsLicenseFileSourceEntryRepository(DirectoryInfo root, BuildLibraryMode buildLibraryMode)
            : base(root, buildLibraryMode)
        {
        }

        public override void Update(string sourceName)
        {
            Log.It.Debug("Updating source entry repository '{0}'", sourceName);

            Entries.Clear();
            if (Directory.Exists(Root.FullName) == false)
                return;

            foreach (var file in Root.EnumerateFiles("*.xml", SearchOption.AllDirectories))
            {
                Log.It.Debug("Adding '{0}' from directory", file.Name);
                var licenseSourceEntry = new LicenseFileSourceEntry(file, sourceName);
                if (Entries.ContainsKey(licenseSourceEntry.Key.ToLower()))
                    continue;
                Entries.Add(licenseSourceEntry.Key.ToLower(), licenseSourceEntry);
            }
        }

        public override BuildLibraryResource Get(SourceEntry sourceEntry)
        {
            var key = sourceEntry.Key.ToLower();
            if (Entries.ContainsKey(key) == false)
                return null;

            var fileInfo = ((LicenseFileSourceEntry)Entries[key]).LicenseFile.File;

            return new BuildLibraryFile(fileInfo, Mode);
        }

    }
}
