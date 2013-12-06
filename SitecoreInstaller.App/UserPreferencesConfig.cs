using SitecoreInstaller.Framework.Configuration;

namespace SitecoreInstaller.App
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "UserPreferences", IsNullable = false)]
    public class UserPreferencesConfig : IConfig
    {
        public void ResetToDefaultSettings()
        {
            ProjectsFolder = @"c:\inetpub\sitecoreinstallerwwwroot";
            LocalBuildLibrary = @"c:\BuildLibrary";
            IisSitePostfix = string.Empty;

            SqlInstanceName = ".";
            SqlLogin = "sc";
            SqlPassword = "1234";

            MongoEndpoint = @"localhost";
            MongoPort = 27017;
            MongoUsername = string.Empty;
            MongoPassword = string.Empty;

            AdvancedView = false;
            PromptForUserSettings = true;

            LicenseExpirationPeriodInDays = 14;
        }

        public string ProjectsFolder { get; set; }

        public string LocalBuildLibrary { get; set; }

        [XmlIgnore]
        public string ArchiveFolder
        {
            get { return LocalBuildLibrary + @"\sitecore"; }
        }

        public string IisSitePostfix { get; set; }

        public string SqlInstanceName { get; set; }
        public string SqlLogin { get; set; }
        public string SqlPassword { get; set; }

        public string MongoEndpoint { get; set; }
        public int MongoPort { get; set; }
        public string MongoUsername { get; set; }
        public string MongoPassword { get; set; }

        public bool AdvancedView { get; set; }

        public bool PromptForUserSettings { get; set; }

        public int LicenseExpirationPeriodInDays { get; set; }
    }
}
