using System;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Tests.Domain.BuildLibrary
{
    [TestFixture]
    public class LicenseFileUT
    {
        private LicenseFile _licenseFile;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _licenseFile = new LicenseFile(Resource.TestLicense, DateTime.Now);
        }

        [Test]
        public void Init_Parsing_ExpirationDateIsSet()
        {
            var expectedExpiration = new DateTime(2012, 2, 23);
            _licenseFile.ExpirationDate.Should().Be(expectedExpiration);
        }
        [Test]
        public void Init_Parsing_LicenseeIsSet()
        {
            const string expectedLicensee = "Sitecore Japan (Test)";
            _licenseFile.Licensee.Should().BeEquivalentTo(expectedLicensee);
        }
        [Test]
        public void IsExpired_Expiration_LicenseIsExpired()
        {
            var referenceTime = new DateTime(2012, 2, 24);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);
            _licenseFile.IsExpired.Should().BeTrue();
        }
        [Test]
        public void ExpiresIn_Expiration_DaysToExpiration()
        {
            var referenceTime = new DateTime(2012, 2, 20);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);

            _licenseFile.ExpiresIn.Should().Be(3);
        }
        [Test]
        public void ExpiresIn_Expiration_LicenseIsExpired()
        {
            var referenceTime = new DateTime(2015, 12, 26);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);

            _licenseFile.ExpiresIn.Should().Be(0);
        }

        [Test]
        public void ExpiresWithin_Expiration_LicenseIsNoExpired()
        {
            var referenceTime = new DateTime(2012, 2, 22);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);

            const int ExpiresWithinDays = 1;

            _licenseFile.ExpiresWithin(ExpiresWithinDays).Should().BeTrue();
        }

        [Test]
        public void ToString_formatting_StringIsLicenseeAndExpiratoinDate()
        {
            const string expectedString = "Sitecore Japan (Test) (2012-02-23)";
            _licenseFile.ToString().Should().BeEquivalentTo(expectedString);
        }
    }
}
