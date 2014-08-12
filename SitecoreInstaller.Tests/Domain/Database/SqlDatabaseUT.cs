using System.IO;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain.Database;

namespace SitecoreInstaller.Tests.Domain.Database
{
    [TestFixture]
    public class SqlDatabaseUT
    {
        private SqlDatabase _database;

        [Test]
        [TestCase("SiteSetter.Sitecore.Web", "Web")]
        [TestCase("SiteSetter_Sitecore_Web", "Web")]
        [TestCase("Andes.Reporting.Secondary", "Reporting_Secondary")]
        [TestCase("Andes_Reporting_Secondary", "Reporting_Secondary")]
        [TestCase("Sitecore.Reporting.Secondary", "Reporting.Secondary"), Ignore]//what is the proper expected value?
        public void LogicalName_DetermineLogicalName_LogicalNameDoesntTakeTheWordSitecoreIntoAccount(string physicalDbName, string expectedLogicalName)
        {
            const string projectName = "MyProject";
            var db = new SqlDatabase(new DirectoryInfo("."), physicalDbName, projectName);

            db.LogicalName.Should().Be(expectedLogicalName);
            db.Name.Should().Be(string.Format("{0}_{1}", projectName, expectedLogicalName));
        }


        [Test]
        public void Ctor_PathResolving_PathsAreResolved()
        {
            var path = new DirectoryInfo(@"c:\databases");
            const string physicalDatbaseName = "mySqlDatabase_Core";
            const string projectName = "MyProject";

            _database = new SqlDatabase(path, physicalDatbaseName, projectName);

            _database.Name.Should().BeEquivalentTo(projectName + "_Core");
            _database.PhysicalName.Should().BeEquivalentTo(physicalDatbaseName);
            _database.LogicalName.Should().BeEquivalentTo("Core");
            _database.DataFileFullPath.Should().BeEquivalentTo(path + "\\" + physicalDatbaseName + ".mdf");
            _database.LogFileFullPath.Should().BeEquivalentTo(path + "\\" + physicalDatbaseName + ".ldf");
        }
    }
}
