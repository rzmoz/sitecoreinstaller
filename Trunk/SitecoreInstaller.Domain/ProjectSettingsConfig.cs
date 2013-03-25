using System.Collections.Generic;

namespace SitecoreInstaller.Domain
{
  using System;
  using System.Xml.Serialization;
  using SitecoreInstaller.Framework.Configuration;

  [XmlRoot(ElementName = "ProjectSettings", IsNullable = false)]
  public class ProjectSettingsConfig : IConfig
  {
    public ProjectSettingsConfig()
    {
      Sitecore = string.Empty;
      License = string.Empty;
      Modules = new List<string>();
    }

    public string Sitecore { get; set; }

    public string License { get; set; }

    [XmlArrayItem(ElementName = "Module", IsNullable = false)]
    public List<string> Modules { get; set; }
  }
}
