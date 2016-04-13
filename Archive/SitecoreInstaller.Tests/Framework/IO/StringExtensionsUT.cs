using System;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Framework.IOx;
using SitecoreInstaller.Framework.Sys;
namespace SitecoreInstaller.Tests.Framework.IO
{
    [TestFixture]
    public class StringExtensionsUT
    {
        [Test]
        public void Replace_IgnoreCase_RaplceWorksWithCaseIgnore()
        {
            var fullstring = "Lorem Ipsum Dolor SIT amet, consectetur adipiscing elit.";

            var replaced = fullstring.ReplaceCaseInsensitive(" dOLOR sit AMET", "Haloo");

            replaced.Should().Be("Lorem IpsumHaloo, consectetur adipiscing elit.");
        }

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
