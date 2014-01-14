using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain.Database;

namespace SitecoreInstaller.Tests.Domain.Database
{
    [TestFixture]
    public class ConnectionStringNameUT
    {
        [Test]
        public void NameParts_MultiDelimitedName_NameIsParsed()
        {
            const string databaseName = "qa.pandora_ecm_siteore_core";

            var connectionStringName = new ConnectionStringName(databaseName);

            connectionStringName.DatabasePart.Should().Be("core");
            connectionStringName.ProjectPart.Should().Be("qa.pandora_ecm_siteore");
        }
    }
}
