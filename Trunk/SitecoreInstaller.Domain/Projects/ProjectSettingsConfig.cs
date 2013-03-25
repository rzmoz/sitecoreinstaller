namespace SitecoreInstaller.Domain.Projects
{
  using System.Collections.Generic;
  using System.Xml.Serialization;
  using SitecoreInstaller.Framework.Configuration;

  [XmlRoot(ElementName = "ProjectSettings", IsNullable = false)]
  public class ProjectSettingsConfig : IConfig
  {
    public ProjectSettingsConfig()
    {
      this.Sitecore = string.Empty;
      this.License = string.Empty;
      this.Modules = new List<string>();
    }

    public string Sitecore { get; set; }

    public string License { get; set; }

    [XmlArrayItem(ElementName = "Module", IsNullable = false)]
    public List<string> Modules { get; set; }
  }
}
