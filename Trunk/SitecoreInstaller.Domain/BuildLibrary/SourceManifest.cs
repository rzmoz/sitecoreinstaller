namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System.Xml.Serialization;

  public class SourceManifest
  {
    public SourceManifest()
    {
    }

    public SourceManifest(string name, string type, string parameters)
    {
      Name = name ?? string.Empty;
      Type = type ?? string.Empty;
      Parameters = parameters ?? string.Empty;
    }

    [XmlAttribute]
    public string Name { get; set; }
    
    [XmlAttribute]
    public string Type { get; set; }
    
    [XmlAttribute]
    public string Parameters { get; set; }
  }
}
