using System;
using System.IO;
using DotNet.Basics.IO;
using FluentAssertions;
using SitecoreInstaller.BuildLibrary;
using Xunit;

namespace SitecoreInstallerTests.BuildLibrary
{

    public class LicenseInfoTests
    {
        [Fact]
        public void Ctor_MissingLicenseModule_ExceptionIsThrown()
        {
            Action action = () => LicenseInfo.Parse("", "<xml></xml>");
            action.ShouldThrow<ArgumentException>().WithMessage("License module: SiteCore.License not found in license info");
        }

        [Fact]
        public void Ctor_ParseXml_InfoIsParsed()
        {
            var file = Directory.GetCurrentDirectory().ToFile("BuildLibrary", "TestLicense.xml");
            var li = LicenseInfo.Load(file);

            li.Id.Should().Be("20111225205156");
            li.Licensee.Should().Be("Sitecore Japan (Test)");
            li.Expiration.Should().Be("20120223T120000");
        }
    }
}
