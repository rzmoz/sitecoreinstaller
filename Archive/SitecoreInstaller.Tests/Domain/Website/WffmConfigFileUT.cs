using System.Xml.Linq;
using NUnit.Framework;
using SitecoreInstaller.Domain.Website;

namespace SitecoreInstaller.Tests.Domain.Website
{
    [TestFixture]
    public class WffmConfigFileUT
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {

        }

        [Test]
        public void DataProviderType_DataProvider_DataProviderIsSql()
        {
            var configFile = XDocument.Parse(WebsiteTestResource.formsSQL);

            var wffmConfigFile = new WffmConfigFile(configFile);

            Assert.AreEqual(DataProviderType.Sql, wffmConfigFile.DataProviderType);
        }
        [Test]
        public void DataProviderType_DataProvider_DataProviderIsSqlLite()
        {
            var configFile = XDocument.Parse(WebsiteTestResource.formsSQLite);

            var wffmConfigFile = new WffmConfigFile(configFile);

            Assert.AreEqual(DataProviderType.SQLite, wffmConfigFile.DataProviderType);
        }
        [Test]
        public void DataProviderType_DataProvider_DataProviderIsOracle()
        {
            var configFile = XDocument.Parse(WebsiteTestResource.formsOracle);

            var wffmConfigFile = new WffmConfigFile(configFile);

            Assert.AreEqual(DataProviderType.Oracle, wffmConfigFile.DataProviderType);
        }
    }
}
