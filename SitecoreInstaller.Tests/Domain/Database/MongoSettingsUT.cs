using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain.Database;

namespace SitecoreInstaller.Tests.Domain.Database
{
  [TestFixture]
  public class MongoSettingsUT
  {
    [Test]
    public void TestConnection_Verification_ConnectionShouldFail()
    {
      var settings = new MongoSettings {Endpoint = "ThisEndPointMustNotExistIfTestShouldPass"};
      var isValid = settings.TestConnection();
      isValid.Should().BeFalse();
    }
  }
}
