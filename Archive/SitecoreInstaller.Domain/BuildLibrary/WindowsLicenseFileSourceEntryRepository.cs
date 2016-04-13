using System.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class WindowsLicenseFileSourceEntryRepository : WindowsSourceEntryRepository
    {
        public WindowsLicenseFileSourceEntryRepository(DirectoryInfo root, BuildLibraryMode buildLibraryMode)
            : base(root, buildLibraryMode, SourceType.License)
        {
        }

        public override void Update(string sourceName)
        {
            //Log.This.Debug("Updating Licenses from '{0}'", sourceName);

            Entries.Clear();
            if (Directory.Exists(Root.FullName) == false)
                return;

            foreach (var file in Root.EnumerateFiles("*.xml", SearchOption.AllDirectories))
            {
                //Log.This.Debug("Adding '{0}' from directory", file.FullName);
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
