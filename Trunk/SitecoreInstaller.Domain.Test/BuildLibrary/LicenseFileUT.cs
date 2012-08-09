using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Test.BuildLibrary
{
    using NUnit.Framework;

    using SitecoreInstaller.Domain.BuildLibrary;

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
            Assert.AreEqual(expectedExpiration, _licenseFile.ExpirationDate);
        }
        [Test]
        public void Init_Parsing_LicenseeIsSet()
        {
            const string expectedLicensee = "Sitecore Japan (Test)";
            Assert.AreEqual(expectedLicensee, _licenseFile.Licensee);
        }
        [Test]
        public void IsExpired_Expiration_LicenseIsExpired()
        {
            var referenceTime = new DateTime(2012, 2, 24);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);
            Assert.IsTrue(_licenseFile.IsExpired);
        }
        [Test]
        public void ExpiresIn_Expiration_DaysToExpiration()
        {
            var referenceTime = new DateTime(2012, 2, 20);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);

            const int ExpectedExpiresIn = 3;

            Assert.AreEqual(ExpectedExpiresIn, _licenseFile.ExpiresIn);
        }
        [Test]
        public void ExpiresIn_Expiration_LicenseIsExpired()
        {
            var referenceTime = new DateTime(2015, 12, 26);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);

            const int ExpectedExpiresIn = 0;

            Assert.AreEqual(ExpectedExpiresIn, _licenseFile.ExpiresIn);
        }

        [Test]
        public void ExpiresWithin_Expiration_LicenseIsNoExpired()
        {
            var referenceTime = new DateTime(2012, 2, 22);
            _licenseFile = new LicenseFile(Resource.TestLicense, referenceTime);

            const int ExpiresWithinDays = 1;

            Assert.IsTrue(_licenseFile.ExpiresWithin(ExpiresWithinDays));
        }

        [Test]
        public void ToString_formatting_StringIsLicenseeAndExpiratoinDate()
        {
            const string expectedString = "Sitecore Japan (Test) (2012-02-23)";

            Assert.AreEqual(expectedString, _licenseFile.ToString());
        }
    }
}
