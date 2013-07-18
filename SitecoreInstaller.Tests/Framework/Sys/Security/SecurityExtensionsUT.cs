using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsAuthentication = System.Web.Security.FormsAuthentication;

namespace SitecoreInstaller.Tests.Framework.Sys.Security
{
  using FluentAssertions;
  using NUnit.Framework;
  using SitecoreInstaller.Framework.Sys.Security;

  [TestFixture]
  public class SecurityExtensionsUT
  {
    [Test]
    public void ToMD5String_HashString_StringIsHashed()
    {
      const string str = "xdflkghsd gdhsrgse rltg w34ot yqg 4tiuwh3ow3htyg awe8o3b 6";

      var result = str.ToMD5String();
      var expected = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");

      result.Should().Be(expected);
    }
  }
}
