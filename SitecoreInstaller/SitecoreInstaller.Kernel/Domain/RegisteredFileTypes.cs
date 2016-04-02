using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Kernel.Domain
{
    public static class RegisteredFileTypes
    {
        private static readonly HashSet<string> _knownFileTypes;

        static RegisteredFileTypes()
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


        public static bool IsNotRegisteredFileType(IoFile file)
        {
            return _knownFileTypes.All(knownFileType => !file.Name.ToLowerInvariant().EndsWith(knownFileType));
        }

        public static FileType SqlMdf { get; }
        public static FileType SqlLdf { get; }
        public static FileType SitecoreConfig { get; }
        public static FileType DisabledSitecoreConfig { get; }
        public static FileType SitecorePackage { get; }
        public static FileType SitecoreUpdate { get; }
        public static FileType SitecoreSettings { get; }
        public static FileType PowerShellScript { get; }
        public static FileType ConfigDelta { get; }

    }
}
