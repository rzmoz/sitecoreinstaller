using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitecoreInstaller.Domain.Database;


namespace SitecoreLocalInstallerTest.Model
{
    [TestFixture]
    public class TSqlServiceUT
    {
        private TSqlService _sqlService;

        string _projectName;
        string _databaseFolder;
        private IEnumerable<string> _databaseNames;


        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _sqlService = new TSqlService();
            _projectName = "Azure";
            _databaseFolder = @"C:\Projects\Azure\Databases";
            _databaseNames = new[] { "Sitecore.Core", "Sitecore.Master", "Sitecore.Web" };
        }

        [Test]
        [TestCase("NicamBuildNicamDemo_Analytics", "Analytics")]
        [TestCase("Sitecore.Core", "Core")]
        public void GetLogicalDatabaseName_TrimPhysicalFilename_LogicalName(string physicalDatabaseName, string expected)
        {
            var logicalName = _sqlService.GetLogicalDatabaseName(physicalDatabaseName);

            Assert.AreEqual(expected, logicalName);
        }




        [Test]
        public void GetAttachScript()
        {

            var generatedScript = _sqlService.GetAttachScript(_projectName, _databaseNames, _databaseFolder);

            const string expectedScript = @"USE [master]
GO
CREATE DATABASE [Azure_Core] ON
( FILENAME = N'C:\Projects\Azure\Databases\Sitecore.Core.Mdf' ),
( FILENAME = N'C:\Projects\Azure\Databases\Sitecore.Core.Ldf' )
FOR ATTACH
GO

USE [master]
GO
CREATE DATABASE [Azure_Master] ON
( FILENAME = N'C:\Projects\Azure\Databases\Sitecore.Master.Mdf' ),
( FILENAME = N'C:\Projects\Azure\Databases\Sitecore.Master.Ldf' )
FOR ATTACH
GO

USE [master]
GO
CREATE DATABASE [Azure_Web] ON
( FILENAME = N'C:\Projects\Azure\Databases\Sitecore.Web.Mdf' ),
( FILENAME = N'C:\Projects\Azure\Databases\Sitecore.Web.Ldf' )
FOR ATTACH
GO";
            Assert.AreEqual(expectedScript, generatedScript);
        }

        [Test]
        public void GetDetachScript()
        {
            var generatedScript = _sqlService.GetDetachScript(_projectName, _databaseNames);

            const string expectedScript = @"USE [master]
GO
ALTER DATABASE [Azure_Core] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
EXEC master.dbo.sp_detach_db @dbname = N'Azure_Core'
GO

USE [master]
GO
ALTER DATABASE [Azure_Master] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
EXEC master.dbo.sp_detach_db @dbname = N'Azure_Master'
GO

USE [master]
GO
ALTER DATABASE [Azure_Web] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
EXEC master.dbo.sp_detach_db @dbname = N'Azure_Web'
GO";
            Assert.AreEqual(expectedScript, generatedScript);
        }
        [Test]
        public void GetMapLoginScript()
        {
            var generatedScript = _sqlService.GetMapLoginScript(_projectName, "sc", _databaseNames);

            const string expectedScript = @"USE [Azure_Core];
CREATE USER [sc] FROM LOGIN [sc];
USE [Azure_Core];
EXEC sp_addrolemember 'db_owner', 'sc';

USE [Azure_Master];
CREATE USER [sc] FROM LOGIN [sc];
USE [Azure_Master];
EXEC sp_addrolemember 'db_owner', 'sc';

USE [Azure_Web];
CREATE USER [sc] FROM LOGIN [sc];
USE [Azure_Web];
EXEC sp_addrolemember 'db_owner', 'sc';";
            Assert.AreEqual(expectedScript, generatedScript);
        }
    }
}
