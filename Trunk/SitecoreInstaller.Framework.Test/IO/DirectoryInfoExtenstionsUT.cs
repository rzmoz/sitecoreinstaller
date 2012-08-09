using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.Framework.IO;
namespace SitecoreInstaller.App.Test.IO
{
    using NUnit.Framework;

    using SitecoreInstaller.Framework.System;

    using global::System.IO;

    [TestFixture]
    public class DirectoryInfoExtenstionsUT
    {
        private DirectoryInfo _rootDir;
        private DirectoryInfo _testDir;
        private FileInfo _testFile;
        private string _testString;

        [SetUp]
        public void Setup()
        {
            _rootDir = new DirectoryInfo(@"c:\rootDir");
            _testDir = new DirectoryInfo("test");
            _testFile = new FileInfo("test.txt");
            _testString = "test";
        }

        [Test]
        public void Combine_CombineToDirectoryInfo_ReturnTypeIsDirectoryInfo()
        {
            var returnType = _rootDir.Combine(_testDir);
            Assert.IsNotNull(returnType);
            Assert.IsTrue(returnType is DirectoryInfo);
        }
        [Test]
        public void Combine_CombineToFileInfo_ReturnTypeIsFileInfo()
        {
            var returnType = _rootDir.Combine(_testFile);
            Assert.IsNotNull(returnType);
            Assert.IsTrue(returnType is FileInfo);
        }
        [Test]
        public void Combine_CombineToFileInfo_FullNameIsCorrect()
        {
            var actual = _rootDir.Combine(_testFile).FullName;
            var expected = Path.Combine(_rootDir.FullName, _testFile.Name);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CombineTo_CombineToDirectoryInfo_ReturnTypeIsDirectoryInfo()
        {
            var returnType = _rootDir.CombineTo<DirectoryInfo>(_testString);
            Assert.IsNotNull(returnType);
            Assert.IsTrue(returnType is DirectoryInfo);
        }

        [Test]
        public void CombineTo_CombineToFileInfo_ReturnTypeIsFileInfo()
        {
            var returnType = _rootDir.CombineTo<FileInfo>(_testString);
            Assert.IsNotNull(returnType);
            Assert.IsTrue(returnType is FileInfo);
        }
        [Test]
        public void CombineTo_CombineToFileInfo_FullNameIsCorrect()
        {
            var actual = _rootDir.CombineTo<FileInfo>(_testFile.Name).FullName;
            var expected = Path.Combine(_rootDir.FullName, _testFile.Name);
            Assert.AreEqual(expected, actual);
        }
    }
}
