using System.Collections.Generic;

namespace SitecoreInstaller.Domain
{
  using System;
  using System.Xml.Serialization;
  using SitecoreInstaller.Framework.Configuration;

  public class ProjectSettingsConfig : IConfig
  {
    public ProjectSettingsConfig()
    {
      Sitecore = string.Empty;
      Modules = new List<string>();
    }

    public string Sitecore { get; set; }

    [XmlArrayItem(ElementName = "Module", IsNullable = false)]
    public List<string> Modules { get; set; }
  }
}
