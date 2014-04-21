using System.Collections.Generic;
using System.Xml.Serialization;
using SitecoreInstaller.Framework.Configuration;

namespace SitecoreInstaller.Domain.Projects
{
    [XmlInclude(typeof(SitecoreSettingConfig))]
    [XmlRoot(ElementName = "ProjectSettings", IsNullable = false)]
    public class ProjectSettingsConfig : IConfig
    {
        public ProjectSettingsConfig()
        {
            Sitecore = string.Empty;
            License = string.Empty;
            Modules = new List<string>();
            SqlInstallType = DbInstallType.Auto;
            MongoInstallType = DbInstallType.Auto;
        }

        public string Sitecore { get; set; }
        public string License { get; set; }

        [XmlArrayItem(ElementName = "Module", IsNullable = false)]
        public List<string> Modules { get; set; }

        public DbInstallType SqlInstallType { get; set; }
        public DbInstallType MongoInstallType { get; set; }
    }
}
