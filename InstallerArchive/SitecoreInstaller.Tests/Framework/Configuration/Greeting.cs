using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Tests.Framework.Configuration
{
  public class Greeting
  {
    [XmlAttribute]
    public string Text { get; set; }
    
    [XmlText]
    public string Value { get; set; }
  }
}
