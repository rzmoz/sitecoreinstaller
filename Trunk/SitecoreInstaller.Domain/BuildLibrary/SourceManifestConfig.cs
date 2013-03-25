using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System.Xml.Serialization;
  using SitecoreInstaller.Framework.Configuration;

  [XmlRoot(ElementName = "Sources", IsNullable = false)]
  public class SourceManifestConfig : IConfig
  {
    public SourceManifestConfig()
    {
      this.Manifests = new List<SourceManifest>();
    }

    [XmlArrayItem(ElementName = "Source", IsNullable = false)]
    public List<SourceManifest> Manifests { get; set; }
  }
}
