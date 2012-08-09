using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Test.IO
{
    using NUnit.Framework;

    using SitecoreInstaller.Framework.IO;

    using global::System.IO;

    [TestFixture]
    public class FileSystemInfoExtensionsUT
    {
        private const string _Extension = ".zip";
        private const string _TestNameWithDotInName= "test.dot";
        private const string _TestNameWithoutDotInName = "test";

        [Test]
        public void NameWithoutDotsInName_StripFromFileInfoWithDotsInName_NameWithoutDotsInName()
        {
            var input = new FileInfo(_TestNameWithDotInName + _Extension);
            Assert.AreEqual(_TestNameWithDotInName, input.NameWithoutExtension());
        }
        [Test]
        public void NameWithoutDotsInName_StripFromFileInfoWithoutDotsInName_NameWithoutDotsInName()
        {
            var input = new FileInfo(_TestNameWithoutDotInName + _Extension);
            Assert.AreEqual(_TestNameWithoutDotInName, input.NameWithoutExtension());
        }
        [Test]
        public void NameWithoutDotsInName_StripFromDirectoryInfoWithDotsInName_NameWithoutDotsInName()
        {
            var input = new DirectoryInfo(_TestNameWithDotInName);
            Assert.AreEqual(_TestNameWithDotInName, input.NameWithoutExtension());
        }
        [Test]
        public void NameWithoutDotsInName_StripFromDirectoryInfoWithoutDotsInName_NameWithoutDotsInName()
        {
            var input = new DirectoryInfo(_TestNameWithoutDotInName);
            Assert.AreEqual(_TestNameWithoutDotInName, input.NameWithoutExtension());
        }
    }
}
