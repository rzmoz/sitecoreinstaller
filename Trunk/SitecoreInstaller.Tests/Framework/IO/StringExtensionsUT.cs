using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Test.IO
{
    using NUnit.Framework;

    using SitecoreInstaller.Framework.IO;

    [TestFixture]
    public class StringExtensionsUT
    {
        [Test]
        public void CleanIllegalFileNameChars_RemoveIllegalCharactersFromFilename_FilenameIsClean()
        {
            const string input = "\\/:*?\"<>|";
            const string expected = "";
            Assert.AreEqual(expected, input.CleanIllegalFileNameChars());
        }
        [Test]
        public void CleanIllegalFileNameChars_DontTouchLegalCharacters_FilenameIsUntouched()
        {
            const string input = "Clean";
            Assert.AreEqual(input, input.CleanIllegalFileNameChars());
        }

    }
}
