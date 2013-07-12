﻿namespace SitecoreInstaller.Framework.IO
{
    using global::System.Collections.Generic;
    using global::System.IO;

    public static class FileTypes
    {
        private static readonly HashSet<string> _knownFileTypes;

        static FileTypes()
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
            SitecoreUpdate = new FileType("SitecoreUpdatePackage", ".update");
            _knownFileTypes.Add(SitecoreUpdate.Extension.ToLower());
            PowerShellScript = new FileType("PowerShellScript", ".ps1");
            _knownFileTypes.Add(PowerShellScript.Extension.ToLower());
        }


        public static bool IsNotRegisteredFileType(FileInfo file)
        {
            return !_knownFileTypes.Contains(file.Extension.ToLower());
        }

        public static FileType DatabaseDataFile { get; private set; }
        public static FileType DatabaseLogFile { get; private set; }
        public static FileType SitecoreConfigFile { get; private set; }
        public static FileType SitecorePackage { get; private set; }
        public static FileType SitecoreUpdate { get; private set; }
        public static FileType PowerShellScript { get; private set; }
    }
}
