using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Framework.IO;



namespace SitecoreLocalInstallerTest.Model
{
    using SitecoreInstaller.Framework.Diagnostics;

    [TestFixture]
    public class SqlServiceUT
    {
        private SqlService _sqlService;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _sqlService = new SqlService(new Log());
        }

        [Test]
        public void GetConnectionStringNames_ConnectionStringGeneration_ConnectionStringNamesAreGenerated()
        {
            var connectionName = new[] {"DealerInventory"};

            var connectionStrings = _sqlService.GetConnectionStringNames(connectionName);

            Assert.AreEqual(3, connectionStrings.Count());
        }
    }
}
