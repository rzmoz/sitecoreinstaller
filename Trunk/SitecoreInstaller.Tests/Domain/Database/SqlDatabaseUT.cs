using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Text;

namespace SitecoreInstaller.Domain.Test.Database
{
    using System.IO;

    using NUnit.Framework;

    using SitecoreInstaller.Domain.Database;
  
    [TestFixture]
    public class SqlDatabaseUT
    {
        private SqlDatabase _database;
        
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            
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
            _database.DatafileFullPath.Should().BeEquivalentTo(path + "\\" + physicalDatbaseName + ".mdf");
            _database.LogFileFullPath.Should().BeEquivalentTo(path + "\\" + physicalDatbaseName+ ".ldf");
        }
    }
}
