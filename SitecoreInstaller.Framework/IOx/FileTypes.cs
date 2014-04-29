using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Framework.IOx
{
    public static class FileTypes
    {
        private static readonly HashSet<string> _knownFileTypes;

        static FileTypes()
        {
            _knownFileTypes = new HashSet<string>();

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

            ConfigDelta = new FileType("ConfigFileDelta", ".delta");
            _knownFileTypes.Add(ConfigDelta.Extension.ToLower());

            SitecoreSettings = new FileType("SitecoreSettings", ".scsettings");
            _knownFileTypes.Add(SitecoreSettings.Extension.ToLower());
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

        public static FileType SqlMdf { get; private set; }
        public static FileType SqlLdf { get; private set; }
        public static FileType SitecoreConfig { get; private set; }
        public static FileType DisabledSitecoreConfig { get; private set; }
        public static FileType SitecorePackage { get; private set; }
        public static FileType SitecoreUpdate { get; private set; }
        public static FileType SitecoreSettings { get; private set; }
        public static FileType PowerShellScript { get; private set; }
        public static FileType ConfigDelta { get; private set; }
    }
}
