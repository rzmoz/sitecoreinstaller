namespace SitecoreInstaller.Framework.IO
{
    using global::System.Collections.Generic;
    using global::System.IO;

    public class FileTypes
    {
        private readonly HashSet<string> _knownFileTypes;

        public FileTypes()
        {
            _knownFileTypes = new HashSet<string>();
            DatabaseDataFile = new FileType("DatabaseDataFile", ".mdf");
            _knownFileTypes.Add(DatabaseDataFile.Extension.ToLower());
            DatabaseLogFile = new FileType("DatabaseLogFile", ".ldf");
            _knownFileTypes.Add(DatabaseLogFile.Extension.ToLower());
            SitecoreConfigFile = new FileType("SitecoreConfigFile", ".config");
            _knownFileTypes.Add(SitecoreConfigFile.Extension.ToLower());
            SitecorePackage = new FileType("SitecorePackage", ".zip");
            _knownFileTypes.Add(SitecorePackage.Extension.ToLower());
            this.SitecoreUpdate = new FileType("SitecorePackage", ".update");
            _knownFileTypes.Add(SitecorePackage.Extension.ToLower());
        }

        public bool IsNotRegisteredFileType(FileInfo file)
        {
            return !_knownFileTypes.Contains(file.Extension.ToLower());
        }

        public FileType DatabaseDataFile { get; private set; }
        public FileType DatabaseLogFile { get; private set; }
        public FileType SitecoreConfigFile { get; private set; }
        public FileType SitecorePackage { get; private set; }
        public FileType SitecoreUpdate { get; private set; }
    }
}
