using System.IO;
using NUnit.Framework;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.Tests.Domain
{
    [TestFixture]
    public class ProjectFolderUT
    {
        const string _ProjectFolder = @"c:\projects";

        [TestFixtureSetUp]
        public void FixtureSetup()
        {

        }
        [Test]
        public void ctor_ResolvePaths_ProjectFolderIsSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder, projectFolder.FullName);
        }


        [Test]
        public void ctor_ResolvePaths_WebsiteFolderIsSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder + @"\Website", projectFolder.Website.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_DatabaseFolderIsSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder + @"\Databases", projectFolder.Databases.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_IisLogFolderIsSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder + @"\IisLogFiles", projectFolder.IisLogFiles.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_ConfigFolderIsSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder + @"\Website\App_Config", projectFolder.Website.AppConfig.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_ConfigIncludeFolderIsSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder + @"\Website\App_Config\Include", projectFolder.Website.AppConfig.Include.FullName);
        }
        [Test]
        public void ctor_ResolvePaths_DataFolderOutsideIsSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder + @"\Data", projectFolder.Data.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_PackagesFolderIsOutsideSet()
        {
            var projectFolder = new ProjectFolder(new DirectoryInfo(_ProjectFolder));

            Assert.AreEqual(_ProjectFolder + @"\Data\Packages", projectFolder.Data.Packages.FullName);
        }
    }
}
