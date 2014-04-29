using System.IO;
using NUnit.Framework;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Tests.Framework.IO
{
    [TestFixture]
    public class FileSystemInfoExtensionsUT
    {
        private const string _extension = ".zip";
        private const string _testNameWithDotInName = "test.dot";
        private const string _testNameWithoutDotInName = "test";

        [Test]
        public void NameWithoutDotsInName_StripFromFileInfoWithDotsInName_NameWithoutDotsInName()
        {
            var input = new FileInfo(_testNameWithDotInName + _extension);
            Assert.AreEqual(_testNameWithDotInName, input.NameWithoutExtension());
        }
        [Test]
        public void NameWithoutDotsInName_StripFromFileInfoWithoutDotsInName_NameWithoutDotsInName()
        {
            var input = new FileInfo(_testNameWithoutDotInName + _extension);
            Assert.AreEqual(_testNameWithoutDotInName, input.NameWithoutExtension());
        }
        [Test]
        public void NameWithoutDotsInName_StripFromDirectoryInfoWithDotsInName_NameWithoutDotsInName()
        {
            var input = new DirectoryInfo(_testNameWithDotInName);
            Assert.AreEqual(_testNameWithDotInName, input.NameWithoutExtension());
        }
        [Test]
        public void NameWithoutDotsInName_StripFromDirectoryInfoWithoutDotsInName_NameWithoutDotsInName()
        {
            var input = new DirectoryInfo(_testNameWithoutDotInName);
            Assert.AreEqual(_testNameWithoutDotInName, input.NameWithoutExtension());
        }
    }
}
