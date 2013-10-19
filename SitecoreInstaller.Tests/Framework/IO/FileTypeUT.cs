using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Tests.Framework.IO
{
  [TestFixture]
  public class FileTypeUT
  {
    [Test]
    public void IsType_TwoPartExtensionIsSupport_FileNameIsDetected()
    {
      const string twoPartExtension = ".config.disabled";
      const string fileName = "myFile" + twoPartExtension;

      var fileType = new FileType("TwoPartExtensionFilyType", twoPartExtension );

      fileType.IsType(fileName).Should().BeTrue();
    }
  }
}
