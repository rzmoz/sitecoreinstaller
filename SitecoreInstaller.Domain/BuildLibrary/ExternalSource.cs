using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System.IO;
  using System.Xml.Serialization;
  using SitecoreInstaller.Domain.Website;
  using SitecoreInstaller.Framework.Web;

  public class ExternalSource
  {
    [XmlAttribute]
    public ExternalSourcetype Type { get; set; }

    [XmlAttribute]
    public string Parameters { get; set; }


    public Uri Uri
    {
      get { return Parameters.ToUri(); }
    }
  }
}
