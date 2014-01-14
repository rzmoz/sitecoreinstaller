using System.Collections.Generic;
using System.Xml.Serialization;
using SitecoreInstaller.Framework.Configuration;

namespace SitecoreInstaller.Domain.Projects
{
    [XmlRoot(ElementName = "ProjectSettings", IsNullable = false)]
    public class ProjectSettingsConfig : IConfig
    {
        public ProjectSettingsConfig()
        {
            Sitecore = string.Empty;
            License = string.Empty;
            Modules = new List<string>();
            InstallType = InstallType.Full;
        }

        public string Sitecore { get; set; }

        public string License { get; set; }

        [XmlArrayItem(ElementName = "Module", IsNullable = false)]
        public List<string> Modules { get; set; }

        public InstallType InstallType { get; set; }
    }
}
