using System.Collections.Generic;
using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public static class FileTypes
    {
        private static readonly HashSet<string> _knownFileTypes;

        static FileTypes()
        {
            _knownFileTypes = new HashSet<string>();

            DacPac = new FileType("DacPac", ".dacpac");
            _knownFileTypes.Add(DacPac.Extension.ToLower());

            SqlMdf = new FileType("SqlMdf", ".mdf");
            _knownFileTypes.Add(SqlMdf.Extension.ToLower());

            SqlLdf = new FileType("SqlLdf", ".ldf");
            _knownFileTypes.Add(SqlLdf.Extension.ToLower());

            SitecoreConfig = new FileType("SitecoreConfig", ".config");
            _knownFileTypes.Add(SitecoreConfig.Extension.ToLower());

            DisabledSitecoreConfig = new FileType("DisabledSitecoreConfig", ".config.disabled");
            _knownFileTypes.Add(DisabledSitecoreConfig.Extension.ToLower());

            SitecorePackage = new FileType("SitecorePackage", ".zip");
            _knownFileTypes.Add(SitecorePackage.Extension.ToLower());

            SitecoreUpdate = new FileType("SitecoreUpdatePackage", ".update");
            _knownFileTypes.Add(SitecoreUpdate.Extension.ToLower());

            PowerShellScript = new FileType("PowerShellScript", ".ps1");
            _knownFileTypes.Add(PowerShellScript.Extension.ToLower());

            ConfigXdt = new FileType("ConfigFileXdt", ".xdt");
            _knownFileTypes.Add(ConfigXdt.Extension.ToLower());
        }


        public static bool IsNotRegisteredFileType(FileInfo file)
        {
            foreach (var knownFileType in _knownFileTypes)
            {
                if (file.Name.ToLowerInvariant().EndsWith(knownFileType))
                    return false;
            }
            return true;
        }

        public static FileType DacPac { get; }
        public static FileType SqlMdf { get; }
        public static FileType SqlLdf { get; }
        public static FileType SitecoreConfig { get; }
        public static FileType DisabledSitecoreConfig { get; }
        public static FileType SitecorePackage { get; }
        public static FileType SitecoreUpdate { get; }
        public static FileType PowerShellScript { get; }
        public static FileType ConfigXdt { get; }
    }
}
