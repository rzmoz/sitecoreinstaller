using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.WebServer
{
  using System.Runtime.Serialization;

  using SitecoreInstaller.Framework.System;

  [DataContract]
  public class ClrVersion : EnumClass
  {
    public static readonly ClrVersion V20 = new ClrVersion("v2.0");
    public static readonly ClrVersion V40 = new ClrVersion("v4.0");

    static ClrVersion()
    {
      Names = new List<ClrVersion> { V20, V40 };
    }

    public ClrVersion(string value)
      : base(value)
    {
    }

    public static IEnumerable<ClrVersion> Names { get; private set; }
  }
}
