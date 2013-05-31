namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System.Xml.Serialization;

  public class SourceManifest
  {
    public SourceManifest()
    {
      this.Enabled = true;
    }

    [XmlAttribute]
    public bool Enabled { get; set; }

    [XmlAttribute]
    public string Name { get; set; }
    
    [XmlAttribute]
    public string Type { get; set; }
    
    [XmlAttribute]
    public string Parameters { get; set; }
  }
}
