using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App
{
    internal static class AppConstants
    {
        internal const string ConnectionStringsConfigFileName = "ConnectionStrings.config";
        internal const string WffmConfigFileName = "forms.config";

        internal const string AppSettingsConfigFileName = "AppSettings.config";
        internal const string PreferencesOverrideConfigFileName = "Preferences.config";
        internal const string SourcesConfigFileName = "Sources.config";

        //prefix with z to make sure they are evaluated last
        internal const string LicenseConfigFileName = "zLicense.config";
        internal const string DataFolderConfigFileName = "zDataFolder.config";
        internal const string WffmSqlDataproviderConfigFileName = "zFormsSqlDataProvider.config";
    }
}
