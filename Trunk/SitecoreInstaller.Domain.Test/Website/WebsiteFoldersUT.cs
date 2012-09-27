using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Test.Website
{
    using System.IO;

    using NUnit.Framework;

    using SitecoreInstaller.Domain.Website;

    [TestFixture]
    public class WebsiteFoldersUT
    {
        const string _ProjectFolder = @"c:\projects";

        [TestFixtureSetUp]
        public void FixtureSetup()
        {

        }
        [Test]
        public void ctor_ResolvePaths_ProjectFolderIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder, websiteFolders.ProjectFolder.FullName);
        }

            
        [Test]
        public void ctor_ResolvePaths_WebsiteFolderIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder + @"\Website", websiteFolders.WebSiteFolder.FullName);
        }
        
        [Test]
        public void ctor_ResolvePaths_DatabaseFolderIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder + @"\Databases", websiteFolders.DatabaseFolder.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_IisLogFolderIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder + @"\IisLogFiles", websiteFolders.IisLogFilesFolder.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_ConfigFolderIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder + @"\Website\App_Config", websiteFolders.ConfigFolder.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_ConfigIncludeFolderIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder + @"\Website\App_Config\Include", websiteFolders.ConfigIncludeFolder.FullName);
        }
        [Test]
        public void ctor_ResolvePaths_DataFolderOutsideIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder + @"\Data", websiteFolders.Data.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_DataFolderInsideIsSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.AppDataInside);

            Assert.AreEqual(_ProjectFolder + @"\Website\App_Data", websiteFolders.Data.FullName);
        }

        [Test]
        public void ctor_ResolvePaths_PackagesFolderIsOutsideSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.DataOutside);

            Assert.AreEqual(_ProjectFolder + @"\Data\Packages", websiteFolders.Data.Packages.FullName);
        }
        [Test]
        public void ctor_ResolvePaths_PackagesFolderIsInsideSet()
        {
            var websiteFolders = new WebsiteFolders(new DirectoryInfo(_ProjectFolder), DataFolderMode.AppDataInside);

            Assert.AreEqual(_ProjectFolder + @"\Website\App_Data\Packages", websiteFolders.Data.Packages.FullName);
        }
    }
}
