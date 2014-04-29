using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Framework.IOx;

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

            var fileType = new FileType("TwoPartExtensionFilyType", twoPartExtension);

            fileType.IsType(fileName).Should().BeTrue();
        }
    }
}
