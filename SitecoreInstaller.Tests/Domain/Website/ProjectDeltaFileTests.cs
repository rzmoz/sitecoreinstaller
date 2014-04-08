using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain.Website;

namespace SitecoreInstaller.Tests.Domain.Website
{
    [TestFixture]
    public class ProjectDeltaFileTests
    {
        [Test]
        public void GetRelativePath_GetSubPathInModule_PathIsExtracted()
        {
            //arrange
            const string moduleName = "MyModule";
            const string subPath = @"Website\App_Config\Inclide\MyDeltaFile";
            const string fileExtensions = ".delta";
            var file = new FileInfo(Path.Combine(@"c:\buildlibrary\modules\", moduleName.ToLowerInvariant(), subPath + fileExtensions));

            var deltaFile = new ProjectDeltaFile(moduleName, file);

            //act
            var relativePath = deltaFile.GetRelativePath();

            //assert
            relativePath.Should().Be(subPath);
        }
    }
}
