using System.Collections.Generic;
using System.Xml.Serialization;

namespace SitecoreInstaller.Tests.Framework.Configuration
{
  using SitecoreInstaller.Framework.Configuration;

  public class ConfigFileTest : IConfig
  {
    public ConfigFileTest()
    {
      MyCollection = new List<string>();
    }

    public string Greeting { get; set; }

    [XmlArrayItemAttribute(ElementName = "Item", IsNullable = false)]
    public List<string> MyCollection { get; set; }
  }
}
