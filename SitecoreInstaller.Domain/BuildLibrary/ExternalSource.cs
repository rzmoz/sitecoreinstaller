using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using SitecoreInstaller.Domain.Website;
using SitecoreInstaller.Framework.Web;

namespace SitecoreInstaller.Domain.BuildLibrary
{
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

    protected bool Equals(ExternalSource other)
    {
      return Type == other.Type && string.Equals(Parameters, other.Parameters);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((ExternalSource) obj);
    }

    public override int GetHashCode()
    {
      return (Type + Parameters).GetHashCode();
    }

    public static bool operator ==(ExternalSource left, ExternalSource right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(ExternalSource left, ExternalSource right)
    {
      return !Equals(left, right);
    }
  }
}
