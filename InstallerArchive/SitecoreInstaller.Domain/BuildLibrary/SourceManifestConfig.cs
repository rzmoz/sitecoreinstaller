using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SitecoreInstaller.Framework.Configuration;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    [XmlRoot(ElementName = "Sources", IsNullable = false)]
    public class SourceManifestConfig : IConfig
    {
        public SourceManifestConfig()
        {
            Manifests = new List<SourceManifest>();
        }

        [XmlArrayItem(ElementName = "Manifest", IsNullable = false)]
        public List<SourceManifest> Manifests { get; set; }

        [XmlArrayItem(ElementName = "ExternalSource", IsNullable = false)]
        public List<ExternalSource> ExternalSources { get; set; }
    }
}
