using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Text;

namespace SitecoreInstaller.Domain.Test.Database
{
    using System.IO;

    using NSubstitute;

    using NUnit.Framework;

    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Framework.Diagnostics;

    [TestFixture]
    public class SqlDatabaseUT
    {
        private SqlDatabase _database;
        private ILog _log;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _log = Substitute.For<ILog>();
        }

        [Test]
        public void Ctor_PathResolving_PathsAreResolved()
        {
            var path = new DirectoryInfo(@"c:\databases");
            const string physicalDatbaseName = "mySqlDatabase_Core";
            const string projectName = "MyProject";

            _database = new SqlDatabase(path, physicalDatbaseName, projectName, _log);

            _database.Name.Should().BeEquivalentTo(projectName + "_Core");
            _database.PhysicalName.Should().BeEquivalentTo(physicalDatbaseName);
            _database.LogicalName.Should().BeEquivalentTo("Core");
            _database.DatafileFullPath.Should().BeEquivalentTo(path + "\\" + physicalDatbaseName + ".mdf");
            _database.LogFileFullPath.Should().BeEquivalentTo(path + "\\" + physicalDatbaseName+ ".ldf");
        }
    }
}
